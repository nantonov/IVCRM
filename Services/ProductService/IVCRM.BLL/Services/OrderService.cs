using AutoMapper;
using IVCRM.BLL.Exceptions;
using IVCRM.BLL.Models;
using IVCRM.BLL.Services.Interfaces;
using IVCRM.DAL.Entities;
using IVCRM.DAL.Repositories.Interfaces;

namespace IVCRM.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Order> Create(Order model)
        {
            var entity = _mapper.Map<OrderEntity>(model);
            var result =  await _repository.Create(entity);

            return _mapper.Map<Order>(result);
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            var entity = await _repository.GetAll();

            return _mapper.Map<IEnumerable<Order>>(entity);
        }

        public async Task<OrderDetails> GetById(int id)
        {
            var entity = await _repository.GetById(id);

            return _mapper.Map<OrderDetails>(entity);
        }

        public async Task<Order> Update(Order model)
        {
            if (!await IsEntityExists(model.Id))
            {
                throw new ResourceNotFoundException();
            }

            var entity = _mapper.Map<OrderEntity>(model);
            var result = await _repository.Update(entity);

            return _mapper.Map<Order>(result);
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
