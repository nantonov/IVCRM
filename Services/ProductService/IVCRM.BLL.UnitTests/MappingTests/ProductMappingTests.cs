using IVCRM.API.Profiles;
using IVCRM.API.ViewModels;
using IVCRM.BLL.Models;
using IVCRM.BLL.Profiles;
using IVCRM.BLL.UnitTests.TestData.Entities;
using IVCRM.BLL.UnitTests.TestData.ViewModels;
using IVCRM.DAL.Entities;

namespace IVCRM.BLL.UnitTests.MappingTests
{
    public class ProductMappingTests
    {
        [Fact]
        public void Map_Entity_ReturnsModel()
        {
            //Arrange
            var model = TestProductModels.ProductModel;
            var entity = TestProductEntities.ProductEntity;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<BllMappingProfile>());
            var mapper = config.CreateMapper();

            //Act
            var result = mapper.Map<Product>(entity);

            //Assert
            result.Should().BeEquivalentTo(model);
        }

        [Fact]
        public void Map_Model_ReturnsEntity()
        {
            //Arrange
            var model = TestProductModels.ProductModel;
            var entity = TestProductModels.ProductModel;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<BllMappingProfile>());
            var mapper = config.CreateMapper();

            //Act
            var result = mapper.Map<ProductEntity>(model);

            //Assert
            result.Should().BeEquivalentTo(entity);
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
            result.Should().BeEquivalentTo(viewModel);
        }

        [Fact]
        public void Map_ChangeViewModel_ReturnsModel()
        {
            //Arrange 
            var model = TestProductViewModels.ValidChangeProductViewModel;
            var entity = TestProductModels.ProductModel;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<ApiMappingProfile>());
            var mapper = config.CreateMapper();

            //Act 
            var result = mapper.Map<Product>(entity);

            //Assert 
            result.Should().BeEquivalentTo(model);

        }
    }
}