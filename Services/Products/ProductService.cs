using ApiPrueba.Dtos.Products;
using ApiPrueba.Models;
using ApiPrueba.Repositories.Products;
using AutoMapper;


namespace ApiPrueba.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _ProductRepository;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _ProductRepository = productRepository;
        }

        public async Task<ReadProduct> Create(CreateProduct createUser, CancellationToken cancellationToken)
        {
            Product EntityUser = _mapper.Map<CreateProduct, Product>(createUser);
            EntityUser = await _ProductRepository.Create(EntityUser, cancellationToken);
            ReadProduct dto = _mapper.Map<Product, ReadProduct>(EntityUser);

            return dto;
        }

        public async Task<ReadProduct> Get(int id, CancellationToken cancellationToken)
        {
            Product CurrentProduct = await _ProductRepository.GetByID(id, cancellationToken);
            if (CurrentProduct != null)
            {
                return _mapper.Map<Product, ReadProduct>(CurrentProduct);
            }
            return null;
        }

        public async Task<ICollection<ReadProduct>> GetAll(CancellationToken cancellationToken)
        {
            IEnumerable<Product> CurrentProducts = await _ProductRepository.GetAll(cancellationToken);
            if (CurrentProducts != null)
            {
                var dto = _mapper.Map<IEnumerable<Product>, ICollection<ReadProduct>>(CurrentProducts);
                return dto;
            }
            return null;
        }

        public async Task<ReadProduct> Update(UpdateProduct updateRequest, CancellationToken cancellationToken)
        {
            Product entity = await _ProductRepository.GetByID(updateRequest.Id, cancellationToken);
            entity = _mapper.Map<UpdateProduct, Product>(updateRequest, entity);
            await _ProductRepository.Update(entity, cancellationToken);

            ReadProduct dto = _mapper.Map<Product, ReadProduct>(entity);
            return dto;
        }
    }
}