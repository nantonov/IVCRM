using AutoMapper;
using IVCRM.BLL.Exceptions;
using IVCRM.BLL.Models;
using IVCRM.BLL.Services.Interfaces;
using IVCRM.DAL.Entities;
using IVCRM.DAL.Repositories.Interfaces;

namespace IVCRM.BLL.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _repository;
        private readonly IMapper _mapper;

        public ProductCategoryService(IProductCategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductCategory> Create(ProductCategory model)
        {
            var entity = _mapper.Map<ProductCategoryEntity>(model);
            var result =  await _repository.Create(entity);

            return _mapper.Map<ProductCategory>(result);
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            var entity = _repository.GetAll();

            return _mapper.Map<IEnumerable<ProductCategory>>(entity);
        }

        public async Task<ProductCategory> GetById(int id)
        {
            var entity = await _repository.GetById(id);

            return _mapper.Map<ProductCategory>(entity);
        }

        public async Task<ProductCategory> Update(ProductCategory model)
        {
            if (!await IsEntityExists(model.Id))
            {
                throw new ResourceNotFoundException();
            }

            var entity = _mapper.Map<ProductCategoryEntity>(model);
            var result = await _repository.Update(entity);

            return _mapper.Map<ProductCategory>(result);
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
