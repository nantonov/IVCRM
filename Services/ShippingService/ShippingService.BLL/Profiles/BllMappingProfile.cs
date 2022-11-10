using ShippingService.BLL.Handlers.Commands;
using ShippingService.BLL.Models;
using ShippingService.DAL.Entities;

namespace ShippingService.BLL.Profiles
{
    public class BllMappingProfile : AutoMapper.Profile
    {
        public BllMappingProfile()
        {
            CreateMap<CreateShipmentCommand, ShipmentEntity>().ReverseMap();
            CreateMap<ShipmentEntity, Shipment>();
        }
    }
}
