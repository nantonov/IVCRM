using AutoMapper;
using IVCRM.BLL.Exceptions;
using IVCRM.BLL.Models;
using IVCRM.BLL.Services.Interfaces;
using IVCRM.DAL.Entities;
using IVCRM.DAL.Repositories.Interfaces;

namespace IVCRM.BLL.Services
{
    public class ProductService : BaseService<Product, ProductEntity>, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository repository, IMapper mapper) : base (repository, mapper)
        {
            _productRepository = repository;
        }

        public async Task UpdatePictureUri(int id, string uri)
        {
            if (!await IsEntityExists(id))
            {
                throw new ResourceNotFoundException();
            }

            await _productRepository.UpdatePictureUri(id, uri);
        }
    }
}
