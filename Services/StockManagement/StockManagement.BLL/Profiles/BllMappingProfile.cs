using StockManagement.BLL.Handlers.Commands;
using StockManagement.DAL.Entities;

namespace StockManagement.BLL.Profiles
{
    public class BllMappingProfile : AutoMapper.Profile
    {
        public BllMappingProfile()
        {
            CreateMap<CreateProductCommand, ProductEntity>().ReverseMap();
            CreateMap<ProductEntity, Product>()
                .ForMember(dest => dest.Category, y => y.MapFrom(src => src.Category!.Name));
        }
    }
}
