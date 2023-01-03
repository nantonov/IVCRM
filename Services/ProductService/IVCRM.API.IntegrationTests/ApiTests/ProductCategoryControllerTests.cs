using System.Net;
using IVCRM.TestData.Entities;
using IVCRM.TestData.ViewModels;
using IVCRM.API.ViewModels;

namespace IVCRM.API.IntegrationTests.ApiTests
{
    public class ProductCategoryControllerTests : IntegrationTestsBase
    {
        [Fact]
        public async Task Create_ValidViewModel_ReturnsViewModel()
        {
            //Arrange
            var viewModel = TestProductCategoryViewModels.ValidProductCategoryViewModel;
            var entity = TestProductCategoryEntities.ProductCategoryEntity;

            using var request = new HttpRequestMessage(HttpMethod.Post, $"/api/productCategory");
            request.AddContent(TestProductCategoryViewModels.ValidChangeProductCategoryViewModel);

            //Act
            var actualResult = await Client.SendAsync(request);
            var responseResult = actualResult.GetResponseResult<ProductCategoryViewModel>();

            entity.Id = responseResult.Id;
            viewModel.Id = responseResult.Id;

            //Assert
            actualResult.StatusCode.ShouldBe(HttpStatusCode.OK);
            responseResult.ShouldBeEquivalentTo(viewModel);
            Context.ProductCategories.Last().ShouldBeEquivalentTo(entity);
        }

        [Fact]
        public async Task Create_InvalidViewModel_ReturnsBadRequest()
        {
            //Arrange
            var unchangedCollectionCount = Context.ProductCategories.Count();

            using var request = new HttpRequestMessage(HttpMethod.Post, $"/api/productCategory");
            request.AddContent(TestProductCategoryViewModels.InvalidChangeProductCategoryViewModel);

            //Act
            var actualResult = await Client.SendAsync(request);

            //Assert
            actualResult.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
            Context.ProductCategories.Count().ShouldBe(unchangedCollectionCount);
        }

        [Fact]
        public async Task GetAll_DataExists_ReturnsViewModelCollection()
        {
            //Arrange
            var entityCollection = TestProductCategoryEntities.ProductCategoryEntityCollection;
            var viewModelCollection = TestProductCategoryViewModels.ValidProductCategoryViewModelCollection;
            var entitiesCount = entityCollection.Count;

            await AddRangeToContext(entityCollection);

            using var request = new HttpRequestMessage(HttpMethod.Get, $"/api/productCategory");

            //Act
            var actualResult = await Client.SendAsync(request);
            var responseResult = actualResult.GetResponseResult<IEnumerable<ProductCategoryViewModel>>();
            viewModelCollection.Select(x => x.Id = responseResult.First(z => z.Name == x.Name).Id).ToList();

            //Assert
            actualResult.StatusCode.ShouldBe(HttpStatusCode.OK);
            responseResult.TakeLast(entitiesCount).ToList().ShouldBeEquivalentTo(viewModelCollection);
        }
        
        [Fact]
        public async Task GetById_DataExists_ReturnsViewModel()
        {
            //Arrange
            var entity = TestProductCategoryEntities.ProductCategoryEntity;
            var id = await AddToContext(entity);
            var viewModel = TestProductCategoryViewModels.ValidProductCategoryViewModel;
            viewModel.Id = id;

            using var request = new HttpRequestMessage(HttpMethod.Get, $"/api/productCategory/{id}");

            //Act
            var actualResult = await Client.SendAsync(request);
            var responseResult = actualResult.GetResponseResult<ProductCategoryViewModel>();

            //Assert
            actualResult.StatusCode.ShouldBe(HttpStatusCode.OK);
            responseResult.ShouldBeEquivalentTo(viewModel);
        }

        [Fact]
        public async Task Update_ValidViewModel_ReturnsViewModel()
        {
            //Arrange
            var entity = TestProductCategoryEntities.ProductCategoryEntity;
            var id = await AddToContext(entity);
            var expectedEntity = TestProductCategoryEntities.UpdatedProductCategoryEntity;
            var expectedViewModel = TestProductCategoryViewModels.UpdatedProductCategoryViewModel;
            expectedViewModel.Id = id;
            expectedEntity.Id = id;

            using var request = new HttpRequestMessage(HttpMethod.Put, $"/api/productCategory/{id}");
            request.AddContent(TestProductCategoryViewModels.UpdatedChangeProductCategoryViewModel);

            //Act
            var actualResult = await Client.SendAsync(request);
            var responseResult = actualResult.GetResponseResult<ProductCategoryViewModel>();
            Context.Entry(entity).Reload();

            //Assert
            actualResult.StatusCode.ShouldBe(HttpStatusCode.OK);
            responseResult.ShouldBeEquivalentTo(expectedViewModel);
            entity.ShouldBeEquivalentTo(expectedEntity);
        }

        [Fact]
        public async Task Update_InvalidViewModel_ReturnsBadRequest()
        {
            //Arrange
            var id = 1;
            using var request = new HttpRequestMessage(HttpMethod.Put, $"/api/productCategory/{id}");
            request.AddContent(TestProductCategoryViewModels.InvalidChangeProductCategoryViewModel);

            //Act
            var actualResult = await Client.SendAsync(request);

            //Assert
            actualResult.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Delete_ValidId_DeletesEntity()
        {
            //Arrange
            var entity = TestProductCategoryEntities.ProductCategoryEntity;
            var id = await AddToContext(entity);

            using var request = new HttpRequestMessage(HttpMethod.Delete, $"/api/productCategory/{id}");

            //Act
            var actualResult = await Client.SendAsync(request);

            //Assert
            actualResult.StatusCode.ShouldBe(HttpStatusCode.OK);
            Context.ProductCategories.ShouldNotContain(entity);
        }
    }
}
