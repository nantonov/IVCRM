using AutoMapper;
using IVCRM.API.Requests;
using IVCRM.API.ViewModels;
using IVCRM.BLL.Models;
using IVCRM.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IVCRM.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerRequest request)
        {
            var model = _mapper.Map<Customer>(request);
            var customer = await _service.Create(model);
            var viewModel = _mapper.Map<CustomerViewModel>(customer);

            return Ok(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _service.GetAll();
            if (!customers.Any())
            {
                return NotFound();
            }

            var viewModels = _mapper.Map<List<CustomerViewModel>>(customers);

            return Ok(viewModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var customer = await _service.GetById(id);
            if (customer is null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<CustomerViewModel>(customer);

            return Ok(viewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCustomerRequest request)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var model = _mapper.Map<Customer>(request);
            model.Id = id;

            var customer = await _service.Update(model);
            if (customer is null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<CustomerViewModel>(customer);

            return Ok(viewModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var customer = await _service.Delete(id); ;
            if (customer is null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<CustomerViewModel>(customer);

            return Ok(viewModel);
        }
    }
}