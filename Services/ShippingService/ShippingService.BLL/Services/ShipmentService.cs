using AutoMapper;
using ShippingService.BLL.Models;
using ShippingService.BLL.Services.Interfaces;
using ShippingService.DAL.Entities;
using ShippingService.DAL.Repositories.Interfaces;

namespace ShippingService.BLL.Services
{
    public class ShipmentService : IShipmentService
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IMapper _mapper;

        public ShipmentService(IShipmentRepository customerRepository, IMapper mapper)
        {
            _shipmentRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<Shipment> Create(Shipment model)
        {
            var entity = _mapper.Map<ShipmentEntity>(model);
            var result = await _shipmentRepository.Create(entity);

            return _mapper.Map<Shipment>(result);
        }

        public async Task<Shipment?> GetByOrderId(int orderId)
        {
            var entity = await _shipmentRepository.GetByOrderId(orderId);

            return _mapper.Map<Shipment>(entity);
        }
    }
}
