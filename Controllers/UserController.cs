using System.Net.Mime;
using ApiPrueba.Dtos.Users;
using ApiPrueba.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoWrapper.Wrappers;

namespace ApiPrueba.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _UserService;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _UserService = userService;
            _logger = logger;
        }

        [HttpPost()]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Create([FromBody] CreateUser createRequest, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Create");
            ReadUser result = await _UserService.Create(createRequest, cancellationToken);
            return Ok(new ApiResponse("User create", result, 200));
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Read([FromRoute]int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Read");
            ReadUser response = await _UserService.Get(id, cancellationToken);
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return NotFound("Not found user");
            }
        }

        [HttpPut("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Update([FromRoute]int id, [FromBody] UpdateUser updateRequest, CancellationToken cancellationToken)
        {
            ReadUser response = await _UserService.Get(id, cancellationToken);
            if (response == null)
            {
                return NotFound("Not found user");
            }
            else
            {
                if (updateRequest.Id != id)
                {
                    return BadRequest("AccionParticipacionOCMP Id and id doesn't match");
                }

                response = await _UserService.Update(updateRequest, cancellationToken);
                return Ok(new ApiResponse("User updated", response, 200));

            }
        }

        [HttpGet()]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetAll");
            ICollection<ReadUser> response = await _UserService.GetAll(cancellationToken);
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return NotFound("Not found User");
            }
        }
    }
}