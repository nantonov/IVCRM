using AutoMapper;
using MediatR;
using ShippingService.BLL.Models;
using ShippingService.BLL.Services.Interfaces;

namespace ShippingService.BLL.Handlers.Queries
{
    public class GetShipmentByOrderIdQueryHandler : IRequestHandler<GetShipmentByOrderIdQuery, Shipment>
    {
        private readonly IShipmentService _service;
        private readonly IMapper _mapper;

        public GetShipmentByOrderIdQueryHandler(IShipmentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<Shipment> Handle(GetShipmentByOrderIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _service.GetByOrderId(request.OrderId);

            return _mapper.Map<Shipment>(entity);
        }
    }

}
