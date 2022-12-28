using AutoMapper;
using FluentValidation;
using IVCRM.API.Validators;
using IVCRM.API.ViewModels;
using IVCRM.BLL.Models;
using IVCRM.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IVCRM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        private readonly ChangeOrderValidator _changeOrderValidator;

        public OrderController(
                IOrderService orderService,
                IMapper mapper, 
                ChangeOrderValidator changeOrderValidator
        )
        {
            _orderService = orderService;
            _mapper = mapper;
            _changeOrderValidator = changeOrderValidator;
        }

        [HttpPost]
        public async Task<OrderViewModel> Create([FromBody] ChangeOrderViewModel viewModel)
        {
            await _changeOrderValidator.ValidateAndThrowAsync(viewModel);
            
            var model = _mapper.Map<Order>(viewModel);
            var result = await _orderService.Create(model);

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