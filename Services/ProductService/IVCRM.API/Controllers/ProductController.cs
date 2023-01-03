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
    public class ProductController : ControllerBase
    {
        private const string PicturesCategory = "products";

        private readonly IProductService _productService;
        private readonly IPictureService _pictureService;
        private readonly IMapper _mapper;
        private readonly ChangeProductValidator _changeProductValidator;
        private readonly LoadPictureValidator _loadPictureValidator;

        public ProductController(IProductService productService,
            IPictureService pictureService,
            IMapper mapper,
            ChangeProductValidator changeProductValidator,
            LoadPictureValidator loadPictureValidator)
        {
            _productService = productService;
            _pictureService = pictureService;
            _mapper = mapper;
            _changeProductValidator = changeProductValidator;
            _loadPictureValidator = loadPictureValidator;
        }

        [HttpPost]
        public async Task<ProductViewModel> Create([FromBody] ChangeProductViewModel viewModel)
        {
            await _changeProductValidator.ValidateAndThrowAsync(viewModel);
            
            var model = _mapper.Map<Product>(viewModel);
            var result = await _productService.Create(model);

            return _mapper.Map<ProductViewModel>(result);
        }

        [HttpGet]
        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            var result = await _productService.GetAll();

            return _mapper.Map<IEnumerable<ProductViewModel>>(result);
        }

        [HttpGet("{id}")]
        public async Task<ProductViewModel> GetById(int id)
        {
            var model = await _productService.GetById(id);

            return _mapper.Map<ProductViewModel>(model);
        }

        [HttpPut("{id}")]
        public async Task<ProductViewModel> Update(int id, [FromBody] ChangeProductViewModel viewModel)
        {
            await _changeProductValidator.ValidateAndThrowAsync(viewModel);

            var model = _mapper.Map<Product>(viewModel);
            model.Id = id;

            var result = await _productService.Update(model);

            return _mapper.Map<ProductViewModel>(result);
        }

        [HttpPost]
        public async Task UploadPicture([FromForm] LoadPictureViewModel request)
        {
            await _loadPictureValidator.ValidateAndThrowAsync(request);

            var pictureUri = await _pictureService.UploadPictureAsync(PicturesCategory, request.Id.ToString(), request.Picture.OpenReadStream());

            await _productService.UpdatePictureUri(request.Id, pictureUri);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _productService.Delete(id);
        }
    }
}