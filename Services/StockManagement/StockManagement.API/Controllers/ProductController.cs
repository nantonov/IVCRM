using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockManagement.BLL.Handlers.Queries;
using StockManagement.BLL.Handlers.Commands;
using StockManagement.API.ViewModels;
using StockManagement.API.Validators;
using StockManagement.API.Extensions;
using StockManagement.API.Filters;

namespace StockManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ChangeProductValidator _changeProductValidator;


        public ProductController(IMediator mediator, IMapper mapper, ChangeProductValidator changeProductValidator)
        {
            _mediator = mediator;
            _mapper = mapper;
            _changeProductValidator = changeProductValidator;
        }

        [HttpPost]
        [ValidateFilter]
        public async Task<ProductViewModel> Create([FromBody] ChangeProductViewModel viewModel)
        {
            var validationResult = await _changeProductValidator.ValidateAsync(viewModel);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState);
                return null!;
            }

            var command = _mapper.Map<CreateProductCommand>(viewModel);
            var result = await _mediator.Send(command);

            return _mapper.Map<ProductViewModel>(result);
        }

        [HttpGet]
        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            var result = await _mediator.Send(new GetAllProductQuery());

            return _mapper.Map<IEnumerable<ProductViewModel>>(result);
        }
    }
}