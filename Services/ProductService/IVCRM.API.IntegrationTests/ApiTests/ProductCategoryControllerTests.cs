using IVCRM.API.IntegrationTests.TestData.Entities;
using IVCRM.API.IntegrationTests.TestData.ViewModels;
using IVCRM.API.ViewModels;
using System.Net;

namespace IVCRM.API.IntegrationTests.ApiTests
{
    public class ProductCategoryControllerTests : IntegrationTestsBase
    {
        [Fact]
        public async void Create_ValidViewModel_ReturnsViewModel()
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
            actualResult.StatusCode.Should().Be(HttpStatusCode.OK);
            responseResult.Should().BeEquivalentTo(viewModel);
            Context.ProductCategories.Last().Should().BeEquivalentTo(entity);
        }

        [Fact]
        public async void Create_ViewModelNotValid_ReturnsNotFound()
        {
            //Arrange
            var unchangedCollectionCount = Context.ProductCategories.Count();

            using var request = new HttpRequestMessage(HttpMethod.Post, $"/api/productCategory");
            request.AddContent(TestProductCategoryViewModels.InvalidChangeProductCategoryViewModel);

            //Act
            var actualResult = await Client.SendAsync(request);
            var responseResult = actualResult.GetResponseResult<CustomerViewModel>();

            //Assert
            actualResult.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            Context.ProductCategories.Count().Should().Be(unchangedCollectionCount);
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

            //Assert
            actualResult.StatusCode.Should().Be(HttpStatusCode.OK);
            responseResult.TakeLast(entitiesCount).Should().BeEquivalentTo(viewModelCollection, opt => opt.Excluding(x => x.Id));
        }
        
        [Fact]
        public async Task GetById_WhenDataExists_ShouldViewModel()
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
            actualResult.StatusCode.Should().Be(HttpStatusCode.OK);
            responseResult.Should().BeEquivalentTo(viewModel);
        }

        [Fact]
        public async void Update_ValidViewModel_ReturnsViewModel()
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
            actualResult.StatusCode.Should().Be(HttpStatusCode.OK);
            responseResult.Should().BeEquivalentTo(expectedViewModel);
            entity.Should().BeEquivalentTo(expectedEntity);
        }

        [Fact]
        public async void Update_ViewModelNotValid_ReturnsNotFound()
        {
            //Arrange
            var id = 1;
            using var request = new HttpRequestMessage(HttpMethod.Put, $"/api/productCategory/{id}");
            request.AddContent(TestProductCategoryViewModels.InvalidChangeProductCategoryViewModel);

            //Act
            var actualResult = await Client.SendAsync(request);
            var responseResult = actualResult.GetResponseResult<ProductCategoryViewModel>();

            //Assert
            actualResult.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async void Delete_Id_DeletesEntityWithSameId()
        {
            //Arrange
            var entity = TestProductCategoryEntities.ProductCategoryEntity;
            var id = await AddToContext(entity);

            using var request = new HttpRequestMessage(HttpMethod.Delete, $"/api/productCategory/{id}");

            //Act
            var actualResult = await Client.SendAsync(request);

            //Assert
            actualResult.StatusCode.Should().Be(HttpStatusCode.OK);
            Context.ProductCategories.Should().NotContain(entity);
        }
    }
}
