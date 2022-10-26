using IVCRM.BLL.Models;
using IVCRM.DAL.Entities;

namespace IVCRM.BLL.Profiles
{
    public class BllMappingProfile : AutoMapper.Profile
    {
        public BllMappingProfile()
        {
            CreateMap();
        }

        private void CreateMap()
        {
            CreateMap<Customer, CustomerEntity>().ReverseMap();
        }
    }
}
