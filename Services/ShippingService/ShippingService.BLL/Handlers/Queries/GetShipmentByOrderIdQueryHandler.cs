using AutoMapper;
using MediatR;
using ShippingService.BLL.Models;
using ShippingService.DAL.Repositories.Interfaces;

namespace ShippingService.BLL.Handlers.Queries
{
    public class GetShipmentByOrderIdQueryHandler : IRequestHandler<GetShipmentByOrderIdQuery, Shipment>
    {
        private readonly IShipmentRepository _repository;
        private readonly IMapper _mapper;

        public GetShipmentByOrderIdQueryHandler(IShipmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Shipment> Handle(GetShipmentByOrderIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByOrderId(request.OrderId);

            return _mapper.Map<Shipment>(entity);
        }
    }

}
