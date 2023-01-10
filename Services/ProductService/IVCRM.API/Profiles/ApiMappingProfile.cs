using IVCRM.API.ViewModels;
using IVCRM.BLL.Models;
using IVCRM.Core;

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
            CreateMap<CustomerDetails, CustomerDetailsViewModel>();

            CreateMap<Address, AddressViewModel>();
            CreateMap<ChangeAddressViewModel, Address>();

            CreateMap<Product, ProductViewModel>();
            CreateMap<ChangeProductViewModel, Product>();

            CreateMap<Order, OrderViewModel>();
            CreateMap<OrderDetails, OrderDetailsViewModel>();
            CreateMap<ChangeOrderViewModel, Order>();

            CreateMap<ProductCategory, ProductCategoryViewModel>();
            CreateMap<ChangeProductCategoryViewModel, ProductCategory>();

            CreateMap<ProductOrder, ProductOrderViewModel>();
        }
    }
}
