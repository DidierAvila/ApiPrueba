using ApiPrueba.Dtos.Products;

namespace ApiPrueba.Services.Products
{
    public interface IProductService
    {
        Task<ReadProduct> Get(int id, CancellationToken cancellationToken);
        Task<ICollection<ReadProduct>> GetAll(CancellationToken cancellationToken);
        Task<ReadProduct> Create(CreateProduct createUser, CancellationToken cancellationToken);
        Task<ReadProduct> Update(UpdateProduct updateRequest, CancellationToken cancellationToken);
    }
}