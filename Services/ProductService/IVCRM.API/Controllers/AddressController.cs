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
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _service;
        private readonly IMapper _mapper;
        private readonly ChangeAddressValidator _changeAddressValidator;

        public AddressController(IAddressService service, IMapper mapper, ChangeAddressValidator changeAddressValidator)
        {
            _service = service;
            _mapper = mapper;
            _changeAddressValidator = changeAddressValidator;
        }

        [HttpPost]
        public async Task<AddressViewModel> Create([FromBody] ChangeAddressViewModel viewModel)
        {
            await _changeAddressValidator.ValidateAndThrowAsync(viewModel);
            
            var model = _mapper.Map<Address>(viewModel);
            var result = await _service.Create(model);

            return _mapper.Map<AddressViewModel>(result);
        }

        [HttpGet]
        public async Task<IEnumerable<AddressViewModel>> GetAll()
        {
            var result = await _service.GetAll();

            return _mapper.Map<IEnumerable<AddressViewModel>>(result);
        }

        [HttpGet("{id}")]
        public async Task<AddressViewModel> GetById(int id)
        {
            var model = await _service.GetById(id);

            return _mapper.Map<AddressViewModel>(model);
        }

        [HttpPut("{id}")]
        public async Task<AddressViewModel> Update(int id, [FromBody] ChangeAddressViewModel viewModel)
        {
            await _changeAddressValidator.ValidateAndThrowAsync(viewModel);

            var model = _mapper.Map<Address>(viewModel);
            model.Id = id;

            var result = await _service.Update(model);

            return _mapper.Map<AddressViewModel>(result);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }
    }
}