using IVCRM.BLL.Models;
using IVCRM.Core;
using IVCRM.DAL.Entities;
using Messages.Models;

namespace IVCRM.BLL.Profiles
{
    public class BllMappingProfile : AutoMapper.Profile
    {
        public BllMappingProfile()
        {
            CreateMap<Customer, CustomerEntity>().ReverseMap();
            CreateMap<CustomerEntity, CustomerDetails>();

            CreateMap<Address, AddressEntity>().ReverseMap();

            CreateMap<PagedList<Customer>, PagedList<CustomerEntity>>().ReverseMap();

            CreateMap<Product, ProductEntity>().ReverseMap();

            CreateMap<Order, OrderEntity>().ReverseMap();
            CreateMap<OrderEntity, OrderDetails>();

            CreateMap<OrderItem, OrderItemEntity>().ReverseMap();

            CreateMap<OrderEntity, CreateOrderMessage>();

            CreateMap<ProductCategory, ProductCategoryEntity>().ReverseMap();
        }
    }
}
