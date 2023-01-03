using IVCRM.API.Profiles;
using IVCRM.API.ViewModels;
using IVCRM.BLL.Models;
using IVCRM.BLL.Profiles;
using IVCRM.TestData.Entities;
using IVCRM.TestData.Models;
using IVCRM.TestData.ViewModels;
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
            result.ChildCategories = null;

            //Assert
            result.ShouldBeEquivalentTo(model);
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
            result.ChildCategories = null;

            //Assert
            result.ShouldBeEquivalentTo(entity);
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
            result.ShouldBeEquivalentTo(viewModel);
        }

        [Fact]
        public void Map_ChangeViewModel_ReturnsModel()
        {
            //Arrange 
            var viewModel = TestProductCategoryViewModels.ValidChangeProductCategoryViewModel;
            var model = TestProductCategoryModels.ProductCategoryModel;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<ApiMappingProfile>());
            var mapper = config.CreateMapper();

            //Act 
            var result = mapper.Map<ProductCategory>(viewModel);
            result.Id = model.Id;

            //Assert 
            result.ShouldBeEquivalentTo(model);

        }
    }
}