using IVCRM.BLL.Models;
using IVCRM.DAL.Entities;

namespace SPWB.IVCRM.BLL.Profiles
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
