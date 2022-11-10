using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShippingService.BLL.Handlers.Queries;
using ShippingService.BLL.Handlers.Commands;
using ShippingService.API.ViewModels;
using ShippingService.API.Validators;
using ShippingService.API.Extensions;
using ShippingService.API.Filters;

namespace ShippingService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShipmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ChangeShipmentValidator _changeShipmentValidator;


        public ShipmentController(IMediator mediator, IMapper mapper, ChangeShipmentValidator changeShipmentValidator)
        {
            _mediator = mediator;
            _mapper = mapper;
            _changeShipmentValidator = changeShipmentValidator;
        }

        [HttpPost]
        [ValidateFilter]
        public async Task<ShipmentViewModel> Create([FromBody] ChangeShipmentViewModel viewModel)
        {
            var validationResult = await _changeShipmentValidator.ValidateAsync(viewModel);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState);
                return null!;
            }

            var command = _mapper.Map<CreateShipmentCommand>(viewModel);
            var result = await _mediator.Send(command);

            return _mapper.Map<ShipmentViewModel>(result);
        }

        [HttpGet("orders/{orderId}")]
        public async Task<ShipmentViewModel> GetByOrderId(int orderId)
        {
            var result = await _mediator.Send(new GetShipmentByOrderIdQuery(orderId));

            return _mapper.Map<ShipmentViewModel>(result);
        }
    }
}