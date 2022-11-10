using ShippingService.API.ViewModels;
using ShippingService.BLL.Handlers.Commands;
using ShippingService.BLL.Models;

namespace ShippingService.API.Profiles
{
    public class ApiMappingProfile : AutoMapper.Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<Shipment, ShipmentViewModel>();
            CreateMap<ChangeShipmentViewModel, CreateShipmentCommand>();
        }
    }
}
