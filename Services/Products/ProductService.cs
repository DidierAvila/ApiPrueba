using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPrueba.DbContexts;
using ApiPrueba.Dtos.Products;
using ApiPrueba.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace ApiPrueba.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly PruebasDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public ProductService(PruebasDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<ReadProduct> Get(int id, CancellationToken cancellationToken)
        {
            Product CurrentProduct = await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
            if (CurrentProduct != null)
            {
                ReadProduct readProduct = new();
                var dto = _mapper.Map<Product, ReadProduct>(CurrentProduct);

                return dto;
            }
            return null;
        }

        public async Task<ICollection<ReadProduct>> GetAll(CancellationToken cancellationToken)
        {
            ICollection<ReadProduct> readProducts = new List<ReadProduct>();

            List<Product> CurrentProducts = await _context.Products.ToListAsync(cancellationToken);
            if (CurrentProducts != null)
            {
                var dto = _mapper.Map<List<Product>, ICollection<ReadProduct>>(CurrentProducts);
                return dto;
            }
            return null;
        }
    }
}