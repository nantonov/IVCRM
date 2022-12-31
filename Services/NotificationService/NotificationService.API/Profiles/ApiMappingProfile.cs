using NotificationService.BLL.Models;
using Messages.Models;

namespace NotificationService.API.Profiles
{
    public class ApiMappingProfile : AutoMapper.Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<CreateOrderMessage, CreateOrderMail>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.CustomerEmail));
        }
    }
}
