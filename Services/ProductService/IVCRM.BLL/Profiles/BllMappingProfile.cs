using IVCRM.BLL.Models;
using IVCRM.Core;
using IVCRM.DAL.Entities;

namespace IVCRM.BLL.Profiles
{
    public class BllMappingProfile : AutoMapper.Profile
    {
        public BllMappingProfile()
        {
            CreateMap<Customer, CustomerEntity>().ReverseMap();

            CreateMap<PagedList<Customer>, PagedList<CustomerEntity>>().ReverseMap();

            CreateMap<Product, ProductEntity>().ReverseMap();

            CreateMap<Order, OrderEntity>().ReverseMap();
            CreateMap<OrderEntity, OrderDetails>();

            CreateMap<ProductOrder, ProductOrderEntity>().ReverseMap();

            CreateMap<ProductCategory, ProductCategoryEntity>().ReverseMap();
        }
    }
}
