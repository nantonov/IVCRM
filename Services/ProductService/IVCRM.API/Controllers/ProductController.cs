using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using IVCRM.API.Filters;
using IVCRM.API.Validators;
using IVCRM.API.ViewModels;
using IVCRM.BLL.Models;
using IVCRM.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IVCRM.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;
        private readonly ChangeProductValidator _changeProductValidator;

        public ProductController(IProductService service, IMapper mapper, ChangeProductValidator changeProductValidator)
        {
            _service = service;
            _mapper = mapper;
            _changeProductValidator = changeProductValidator;
        }

        [HttpPost]
        public async Task<ProductViewModel> Create([FromBody] ChangeProductViewModel viewModel)
        {
            await _changeProductValidator.ValidateAndThrowAsync(viewModel);
            
            var model = _mapper.Map<Product>(viewModel);
            var result = await _service.Create(model);

            return _mapper.Map<ProductViewModel>(result);
        }

        [HttpGet]
        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            var result = await _service.GetAll();

            return _mapper.Map<IEnumerable<ProductViewModel>>(result);
        }

        [HttpGet("{id}")]
        public async Task<ProductViewModel> GetById(int id)
        {
            var model = await _service.GetById(id);

            return _mapper.Map<ProductViewModel>(model);
        }

        [HttpPut("{id}")]
        public async Task<ProductViewModel> Update(int id, [FromBody] ChangeProductViewModel viewModel)
        {
            await _changeProductValidator.ValidateAndThrowAsync(viewModel);

            var model = _mapper.Map<Product>(viewModel);
            model.Id = id;

            var result = await _service.Update(model);

            return _mapper.Map<ProductViewModel>(result);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }
    }
}