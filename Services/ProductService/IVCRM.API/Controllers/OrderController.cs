using AutoMapper;
using FluentValidation;
using IVCRM.API.Validators;
using IVCRM.API.ViewModels;
using IVCRM.BLL.Models;
using IVCRM.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IVCRM.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;
        private readonly IMapper _mapper;
        private readonly ChangeOrderValidator _changeOrderValidator;

        public OrderController(IOrderService service, IMapper mapper, ChangeOrderValidator changeOrderValidator)
        {
            _service = service;
            _mapper = mapper;
            _changeOrderValidator = changeOrderValidator;
        }

        [HttpPost]
        public async Task<OrderViewModel> Create([FromBody] ChangeOrderViewModel viewModel)
        {
            await _changeOrderValidator.ValidateAndThrowAsync(viewModel);
            
            var model = _mapper.Map<Order>(viewModel);
            var result = await _service.Create(model);

            return _mapper.Map<OrderViewModel>(result);
        }

        [HttpGet]
        public async Task<IEnumerable<OrderViewModel>> GetAll()
        {
            var result = await _service.GetAll();

            return _mapper.Map<IEnumerable<OrderViewModel>>(result);
        }

        [HttpGet("{id}")]
        public async Task<OrderViewModel> GetById(int id)
        {
            var model = await _service.GetById(id);

            return _mapper.Map<OrderViewModel>(model);
        }

        [HttpPut("{id}")]
        public async Task<OrderViewModel> Update(int id, [FromBody] ChangeOrderViewModel viewModel)
        {
            await _changeOrderValidator.ValidateAndThrowAsync(viewModel);

            var model = _mapper.Map<Order>(viewModel);
            model.Id = id;

            var result = await _service.Update(model);

            return _mapper.Map<OrderViewModel>(result);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }
    }
}