using AutoMapper;
using MediatR;
using ShippingService.BLL.Models;
using ShippingService.DAL.Entities;
using ShippingService.DAL.Repositories.Interfaces;

namespace ShippingService.BLL.Handlers.Commands
{
    public class CreateShipmentCommandHandler : IRequestHandler<CreateShipmentCommand, Shipment>
    {
        private readonly IShipmentRepository _repository;
        private readonly IMapper _mapper;

        public CreateShipmentCommandHandler(IShipmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Shipment> Handle(CreateShipmentCommand command, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ShipmentEntity>(command);
            var product = await _repository.Create(entity);
            return _mapper.Map<Shipment>(product);
        }
    }
}
