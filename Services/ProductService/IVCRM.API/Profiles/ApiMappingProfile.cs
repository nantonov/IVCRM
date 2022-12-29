using IVCRM.API.ViewModels;
using IVCRM.BLL.Models;
using IVCRM.Core;
using Messages;

namespace IVCRM.API.Profiles
{
    public class ApiMappingProfile : AutoMapper.Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>()
                .ForMember(dest => dest.FullName, y => y.MapFrom(src => $"{src.FirstName} {src.LastName}"));
            CreateMap<PagedList<Customer>, PagedList<CustomerViewModel>>().ReverseMap();
            CreateMap<ChangeCustomerViewModel, Customer>();

            CreateMap<Product, ProductViewModel>();
            CreateMap<ChangeProductViewModel, Product>();

            CreateMap<Order, OrderViewModel>();
            CreateMap<ChangeOrderViewModel, Order>();

            CreateMap<ProductCategory, ProductCategoryViewModel>();
            CreateMap<ChangeProductCategoryViewModel, ProductCategory>();
        }
    }
}
