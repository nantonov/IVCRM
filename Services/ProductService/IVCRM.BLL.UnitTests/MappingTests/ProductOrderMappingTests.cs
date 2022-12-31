using IVCRM.API.Profiles;
using IVCRM.API.ViewModels;
using IVCRM.BLL.Models;
using IVCRM.BLL.Profiles;
using IVCRM.BLL.UnitTests.TestData.Entities;
using IVCRM.BLL.UnitTests.TestData.ViewModels;
using IVCRM.DAL.Entities;

namespace IVCRM.BLL.UnitTests.MappingTests
{
    public class ProductOrderMappingTests
    {
        [Fact]
        public void Map_Entity_ReturnsModel()
        {
            //Arrange
            var model = TestProductOrderModels.ProductOrderModel;
            var entity = TestProductOrderEntities.ProductOrderEntity;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<BllMappingProfile>());
            var mapper = config.CreateMapper();

            //Act
            var result = mapper.Map<Product>(entity);

            //Assert
            result.ShouldBeEquivalentTo(model);
        }

        [Fact]
        public void Map_Model_ReturnsViewModel()
        {
            //Arrange 
            var model = TestProductModels.ProductModel;
            var viewModel = TestProductViewModels.ValidProductViewModel;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<ApiMappingProfile>());
            var mapper = config.CreateMapper();

            //Act 
            var result = mapper.Map<ProductViewModel>(model);

            //Assert 
            result.ShouldBeEquivalentTo(viewModel);
        }
    }
}