using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using IVCRM.API.Filters;
using IVCRM.API.Validators;
using IVCRM.API.ViewModels;
using IVCRM.BLL.Models;
using IVCRM.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Tree;

namespace IVCRM.API.Controllers
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
        public async Task<ProductCategoryViewModel> Create([FromBody] ChangeProductCategoryViewModel viewModel)
        {
            await _validator.ValidateAndThrowAsync(viewModel);
            
            var model = _mapper.Map<ProductCategory>(viewModel);
            var result = await _service.Create(model);

            return _mapper.Map<ProductCategoryViewModel>(result);
        }

        [HttpGet]
        public async Task<IEnumerable<ProductCategoryViewModel>> GetAll()
        {
            var categories = await _service.GetAll();

            return _mapper.Map<IEnumerable<ProductCategoryViewModel>>(categories);
        }

        [HttpGet("tree")]
        public IEnumerable<ProductCategoryViewModel> GetCategoriesTree()
        {
            var categories = _service.GetCategoriesTree();

            return _mapper.Map<IEnumerable<ProductCategoryViewModel>>(categories);
        }

        [HttpGet("{id}")]
        public async Task<ProductCategoryViewModel> GetById(int id)
        {
            var model = await _service.GetById(id);

            return _mapper.Map<ProductCategoryViewModel>(model);
        }

        [HttpPut("{id}")]
        public async Task<ProductCategoryViewModel> Update(int id, [FromBody] ChangeProductCategoryViewModel viewModel)
        {
            await _validator.ValidateAndThrowAsync(viewModel);

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