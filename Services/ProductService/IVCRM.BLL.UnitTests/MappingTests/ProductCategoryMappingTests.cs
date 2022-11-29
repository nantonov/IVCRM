using IVCRM.API.Profiles;
using IVCRM.API.ViewModels;
using IVCRM.BLL.Models;
using IVCRM.BLL.Profiles;
using IVCRM.BLL.UnitTests.TestData.Entities;
using IVCRM.BLL.UnitTests.TestData.ViewModels;
using IVCRM.DAL.Entities;

namespace IVCRM.BLL.UnitTests.MappingTests
{
    public class ProductCategoryMappingTests
    {
        [Fact]
        public void Map_Entity_ReturnsModel()
        {
            //Arrange
            var model = TestProductCategoryModels.ProductCategoryModel;
            var entity = TestProductCategoryEntities.ProductCategoryEntity;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<BllMappingProfile>());
            var mapper = config.CreateMapper();

            //Act
            var result = mapper.Map<ProductCategory>(entity);

            //Assert
            result.Should().BeEquivalentTo(model);
        }

        [Fact]
        public void Map_Model_ReturnsEntity()
        {
            //Arrange
            var model = TestProductCategoryModels.ProductCategoryModel;
            var entity = TestProductCategoryEntities.ProductCategoryEntity;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<BllMappingProfile>());
            var mapper = config.CreateMapper();

            //Act
            var result = mapper.Map<ProductCategoryEntity>(model);

            //Assert
            result.Should().BeEquivalentTo(entity);
        }

        [Fact]
        public void Map_Model_ReturnsViewModel()
        {
            //Arrange 
            var model = TestProductCategoryModels.ProductCategoryModel;
            var viewModel = TestProductCategoryViewModels.ValidProductCategoryViewModel;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<ApiMappingProfile>());
            var mapper = config.CreateMapper();

            //Act 
            var result = mapper.Map<ProductCategoryViewModel>(model);

            //Assert 
            result.Should().BeEquivalentTo(viewModel);
        }

        [Fact]
        public void Map_ChangeViewModel_ReturnsModel()
        {
            //Arrange 
            var model = TestProductCategoryViewModels.ValidChangeProductCategoryViewModel;
            var entity = TestProductCategoryModels.ProductCategoryModel;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<ApiMappingProfile>());
            var mapper = config.CreateMapper();

            //Act 
            var result = mapper.Map<ProductCategory>(entity);

            //Assert 
            result.Should().BeEquivalentTo(model);

        }
    }
}