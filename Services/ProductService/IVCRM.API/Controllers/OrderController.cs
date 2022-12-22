using AutoMapper;
using FluentValidation;
using IVCRM.API.Validators;
using IVCRM.API.ViewModels;
using IVCRM.BLL.Models;
using IVCRM.BLL.Services.Interfaces;
using MassTransit;
using MassTransit.Transports;
using Messages;
using Microsoft.AspNetCore.Mvc;

namespace IVCRM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        private readonly ChangeOrderValidator _changeOrderValidator;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IBus _bus;

        public OrderController(
                IOrderService orderService, 
                ICustomerService customerService,
                IMapper mapper, 
                ChangeOrderValidator changeOrderValidator, 
                IPublishEndpoint publishEndpoint
        )
        {
            _orderService = orderService;
            _customerService = customerService;
            _mapper = mapper;
            _changeOrderValidator = changeOrderValidator;
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<OrderViewModel> Create([FromBody] ChangeOrderViewModel viewModel)
        {
            await _changeOrderValidator.ValidateAndThrowAsync(viewModel);
            
            var model = _mapper.Map<Order>(viewModel);
            var result = await _orderService.Create(model);

            var message = _mapper.Map<CreateOrderMessage>(result);
            var customer = await _customerService.GetById(message.CustomerId);
            message.CustomerEmail = customer.Email;

            await _publishEndpoint.Publish<CreateOrderMessage>(message);

            return _mapper.Map<OrderViewModel>(result);
        }

        [HttpGet]
        public async Task<IEnumerable<OrderViewModel>> GetAll()
        {
            var result = await _orderService.GetAll();

            return _mapper.Map<IEnumerable<OrderViewModel>>(result);
        }

        [HttpGet("{id}")]
        public async Task<OrderViewModel> GetById(int id)
        {
            var model = await _orderService.GetById(id);

            return _mapper.Map<OrderViewModel>(model);
        }

        [HttpPut("{id}")]
        public async Task<OrderViewModel> Update(int id, [FromBody] ChangeOrderViewModel viewModel)
        {
            await _changeOrderValidator.ValidateAndThrowAsync(viewModel);

            var model = _mapper.Map<Order>(viewModel);
            model.Id = id;

            var result = await _orderService.Update(model);

            return _mapper.Map<OrderViewModel>(result);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _orderService.Delete(id);
        }
    }
}