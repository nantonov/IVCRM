using IVCRM.BLL.Models;
using IVCRM.DAL.Entities;
using Messages.Models;

namespace IVCRM.BLL.Profiles
{
    public class BllMappingProfile : AutoMapper.Profile
    {
        public BllMappingProfile()
        {
            CreateMap<Customer, CustomerEntity>().ReverseMap();

            CreateMap<Product, ProductEntity>().ReverseMap();

            CreateMap<Order, OrderEntity>().ReverseMap();

            CreateMap<OrderEntity, CreateOrderMessage>();

            CreateMap<ProductCategory, ProductCategoryEntity>().ReverseMap();
        }
    }
}
