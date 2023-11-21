using ApiPrueba.DbContexts;
using ApiPrueba.Extentions;
using ApiPrueba.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
           {
               options.SwaggerDoc("v1", new OpenApiInfo { Title = "Api prueba", Version = "v1" });
               options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
               {
                   In = ParameterLocation.Header,
                   Description = "Ingresa el Token",
                   Name = "Authorization",
                   Type = SecuritySchemeType.Http,
                   BearerFormat = "JWT",
                   Scheme = "bearer"
               });
               options.AddSecurityRequirement(new OpenApiSecurityRequirement{
                {
                    new OpenApiSecurityScheme{
                        Reference = new OpenApiReference {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
               });
           });

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddCors();

builder.Services.AddDbContext<PruebasDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSql"));
});

builder.Services.AddApiPruebaExtention();

var key = builder.Configuration.GetValue<string>("JwtSettings:key");
var keyBytes = Encoding.ASCII.GetBytes(key);

builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "api v1"));
}
app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "api v1");
        options.OAuthClientId(Environment.GetEnvironmentVariable("SWAGGER_CLIENT_ID"));
        options.OAuthClientSecret(Environment.GetEnvironmentVariable("SWAGGER_CLIENT_SECRET"));
        options.OAuthAppName("API Investigacion - Swagger");
        options.OAuthUsePkce();
    }
    );
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors(options => options.WithOrigins(
                "http://localhost:3000",
                "").AllowAnyHeader().AllowAnyMethod().AllowCredentials());
app.MapControllers();

app.Run();
