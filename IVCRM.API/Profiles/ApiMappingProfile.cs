using IVCRM.API.Requests;
using IVCRM.API.ViewModels;
using IVCRM.BLL.Models;

namespace SPWB.SportService.BFF.Profiles
{
    public class ApiMappingProfile : AutoMapper.Profile
    {
        public ApiMappingProfile()
        {
            CreateMap();
        }

        private void CreateMap()
        {
            CreateMap<Customer, CustomerViewModel>()
                .ForMember(dest => dest.FullName, y => y.MapFrom(src => $"{src.FirstName} {src.LastName}"));
            CreateMap<CreateCustomerRequest, Customer>();
            CreateMap<UpdateCustomerRequest, Customer>();
        }
    }
}
