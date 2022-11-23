using AutoMapper;
using FluentValidation.AspNetCore;
using IVCRM.API.Filters;
using IVCRM.API.Validators;
using IVCRM.API.ViewModels;
using IVCRM.BLL.Models;
using IVCRM.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IVCRM.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _service;
        private readonly IMapper _mapper;
        private readonly ChangeProductCategoryValidator _validator;

        public ProductCategoryController(IProductCategoryService service, IMapper mapper, ChangeProductCategoryValidator validator)
        {
            _service = service;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpPost]
        [ValidateFilter]
        public async Task<ProductCategoryViewModel> Create([FromBody] ChangeProductCategoryViewModel viewModel)
        {
            var validationResult = await _validator.ValidateAsync(viewModel);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState);
                return null!;
            }
            
            var model = _mapper.Map<ProductCategory>(viewModel);
            var result = await _service.Create(model);

            return _mapper.Map<ProductCategoryViewModel>(result);
        }

        [HttpGet]
        public IEnumerable<ProductCategoryViewModel> GetAll()
        {
            var categories = _service.GetAll();

            return _mapper.Map<IEnumerable<ProductCategoryViewModel>>(categories);
        }

        [HttpGet("{id}")]
        public async Task<ProductCategoryViewModel> GetById(int id)
        {
            var model = await _service.GetById(id);

            return _mapper.Map<ProductCategoryViewModel>(model);
        }

        [HttpPut("{id}")]
        [ValidateFilter]
        public async Task<ProductCategoryViewModel> Update(int id, [FromBody] ChangeProductCategoryViewModel viewModel)
        {
            var validationResult = await _validator.ValidateAsync(viewModel);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState);
                return null!;
            }

            var model = _mapper.Map<ProductCategory>(viewModel);
            model.Id = id;

            var result = await _service.Update(model);

            return _mapper.Map<ProductCategoryViewModel>(result);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }
    }
}