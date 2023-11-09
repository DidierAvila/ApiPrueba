using ApiPrueba.Models;
using AutoMapper;

namespace ApiPrueba.Dtos.Products.Mappings
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ReadProduct>();
            CreateMap<ReadProduct, Product>();
            CreateMap<UpdateProduct, Product>();
        }
    }
}