using AutoMapper;
using IVCRM.BLL.Exceptions;
using IVCRM.BLL.Models;
using IVCRM.BLL.Services.Interfaces;
using IVCRM.DAL.Entities;
using IVCRM.DAL.Repositories.Interfaces;

namespace IVCRM.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Product> Create(Product model)
        {
            var entity = _mapper.Map<ProductEntity>(model);
            var result =  await _repository.Create(entity);

            return _mapper.Map<Product>(result);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var entity = await _repository.GetAll();

            return _mapper.Map<IEnumerable<Product>>(entity);
        }

        public async Task<Product> GetById(int id)
        {
            var entity = await _repository.GetById(id);

            return _mapper.Map<Product>(entity);
        }

        public async Task<Product> Update(Product model)
        {
            if (!await IsEntityExists(model.Id))
            {
                throw new ResourceNotFoundException();
            }

            var entity = _mapper.Map<ProductEntity>(model);
            var result = await _repository.Update(entity);

            return _mapper.Map<Product>(result);
        }

        public async Task Delete(int id)
        {
            if (!await IsEntityExists(id))
            {
                throw new ResourceNotFoundException();
            }

            await _repository.Delete(id);
        }

        public async Task<bool> IsEntityExists(int id)
        {
            var entity = await _repository.GetById(id);

            return entity is not null;
        }
    }
}
