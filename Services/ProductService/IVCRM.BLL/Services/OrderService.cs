using AutoMapper;
using IVCRM.BLL.Models;
using IVCRM.BLL.Services.Interfaces;
using IVCRM.DAL.Entities;
using IVCRM.DAL.Repositories.Interfaces;
using MassTransit;
using Messages.Models;

namespace IVCRM.BLL.Services
{
    public class OrderService : BaseService<Order, OrderEntity>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IPublishEndpoint _publishEndpoint;

        public OrderService(IOrderRepository orderRepository,
            ICustomerRepository customerRepository,
            IMapper mapper,
            IPublishEndpoint publishEndpoint) : base(orderRepository, mapper)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _publishEndpoint = publishEndpoint;
        }

        public new async Task<Order> Create(Order model)
        {
            var entity = _mapper.Map<OrderEntity>(model);
            var result =  await _orderRepository.Create(entity);

            var message = _mapper.Map<CreateOrderMessage>(result);
            var customer = await _customerRepository.GetById(message.CustomerId);
            message.CustomerEmail = customer.Email;

            await _publishEndpoint.Publish<CreateOrderMessage>(message);

            return _mapper.Map<Order>(result);
        }

        public new async Task<OrderDetails> GetById(int id)
        {
            var entity = await _orderRepository.GetById(id);

            return _mapper.Map<OrderDetails>(entity);
        }
    }
}
