using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPrueba.DbContexts;
using ApiPrueba.Models;

namespace ApiPrueba.Repositories.Products
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(PruebasDbContext context) : base(context)
        {
        }
    }
}