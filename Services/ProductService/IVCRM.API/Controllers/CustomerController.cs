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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;
        private readonly IMapper _mapper;
        private readonly ChangeCustomerValidator _changeCustomerValidator;

        public CustomerController(ICustomerService service, IMapper mapper, ChangeCustomerValidator changeCustomerValidator)
        {
            _service = service;
            _mapper = mapper;
            _changeCustomerValidator = changeCustomerValidator;
        }

        [HttpPost]
        public async Task<CustomerViewModel> Create([FromBody] ChangeCustomerViewModel viewModel)
        {
            await _changeCustomerValidator.ValidateAndThrowAsync(viewModel);
            
            var model = _mapper.Map<Customer>(viewModel);
            var result = await _service.Create(model);

            return _mapper.Map<CustomerViewModel>(result);
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerViewModel>> GetAll()
        {
            var result = await _service.GetAll();

            return _mapper.Map<IEnumerable<CustomerViewModel>>(result);
        }

        [HttpGet("{id}")]
        public async Task<CustomerViewModel> GetById(int id)
        {
            var model = await _service.GetById(id);

            return _mapper.Map<CustomerViewModel>(model);
        }

        [HttpPut("{id}")]
        public async Task<CustomerViewModel> Update(int id, [FromBody] ChangeCustomerViewModel viewModel)
        {
            await _changeCustomerValidator.ValidateAndThrowAsync(viewModel);

            var model = _mapper.Map<Customer>(viewModel);
            model.Id = id;

            var result = await _service.Update(model);

            return _mapper.Map<CustomerViewModel>(result);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }
    }
}