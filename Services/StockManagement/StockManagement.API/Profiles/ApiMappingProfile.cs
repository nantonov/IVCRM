using StockManagement.API.ViewModels;
using StockManagement.BLL.Handlers.Commands;
using StockManagement.DAL.Entities;

namespace StockManagement.API.Profiles
{
    public class ApiMappingProfile : AutoMapper.Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<ChangeProductViewModel, CreateProductCommand>();
        }
    }
}
