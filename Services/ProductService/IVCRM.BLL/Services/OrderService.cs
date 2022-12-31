using AutoMapper;
using IVCRM.BLL.Exceptions;
using IVCRM.BLL.Models;
using IVCRM.BLL.Services.Interfaces;
using IVCRM.DAL.Entities;
using IVCRM.DAL.Repositories.Interfaces;
using MassTransit;
using Messages.Models;

namespace IVCRM.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public OrderService(IOrderRepository orderRepository, ICustomerRepository customerRepository, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<Order> Create(Order model)
        {
            var entity = _mapper.Map<OrderEntity>(model);
            var result =  await _orderRepository.Create(entity);

            var message = _mapper.Map<CreateOrderMessage>(result);
            var customer = await _customerRepository.GetById(message.CustomerId);
            message.CustomerEmail = customer.Email;

            await _publishEndpoint.Publish<CreateOrderMessage>(message);

            return _mapper.Map<Order>(result);
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            var entity = await _orderRepository.GetAll();

            return _mapper.Map<IEnumerable<Order>>(entity);
        }

        public async Task<Order> GetById(int id)
        {
            var entity = await _orderRepository.GetById(id);

            return _mapper.Map<Order>(entity);
        }

        public async Task<Order> Update(Order model)
        {
            if (!await IsEntityExists(model.Id))
            {
                throw new ResourceNotFoundException();
            }

            var entity = _mapper.Map<OrderEntity>(model);
            var result = await _orderRepository.Update(entity);

            return _mapper.Map<Order>(result);
        }

        public async Task Delete(int id)
        {
            if (!await IsEntityExists(id))
            {
                throw new ResourceNotFoundException();
            }

            await _orderRepository.Delete(id);
        }

        public async Task<bool> IsEntityExists(int id)
        {
            var entity = await _orderRepository.GetById(id);

            return entity is not null;
        }
    }
}
