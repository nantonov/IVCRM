using AutoMapper;
using MediatR;
using ShippingService.BLL.Models;
using ShippingService.BLL.Services.Interfaces;

namespace ShippingService.BLL.Handlers.Commands
{
    public class CreateShipmentCommandHandler : IRequestHandler<CreateShipmentCommand, Shipment>
    {
        private readonly IShipmentService _service;
        private readonly IMapper _mapper;

        public CreateShipmentCommandHandler(IShipmentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<Shipment> Handle(CreateShipmentCommand command, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Shipment>(command);
            var result = await _service.Create(model);
            return _mapper.Map<Shipment>(result);
        }
    }
}
