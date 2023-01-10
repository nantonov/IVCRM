using AutoMapper;
using IVCRM.BLL.Exceptions;
using IVCRM.BLL.Models.Interfaces;
using IVCRM.BLL.Services.Interfaces;
using IVCRM.DAL.Entities.Interfaces;
using IVCRM.DAL.Repositories.Interfaces;

namespace IVCRM.BLL.Services
{
    public class BaseService<TModel, TEntity> : IBaseService<TModel> where TEntity : IEntity where TModel : IModel
    {
        protected readonly IBaseRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public BaseService(IBaseRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TModel> Create(TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            var result =  await _repository.Create(entity);

            return _mapper.Map<TModel>(result);
        }

        public virtual async Task<IEnumerable<TModel>> GetAll()
        {
            var entities = await _repository.GetAll();

            return _mapper.Map<IEnumerable<TModel>>(entities);
        }

        public virtual async Task<TModel> GetById(int id)
        {
            var entity = await _repository.GetById(id);

            return _mapper.Map<TModel>(entity);
        }

        public async Task<TModel> Update(TModel model)
        {
            if (!await IsEntityExists(model.Id))
            {
                throw new ResourceNotFoundException();
            }

            var entity = _mapper.Map<TEntity>(model);
            var result = await _repository.Update(entity);

            return _mapper.Map<TModel>(result);
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
