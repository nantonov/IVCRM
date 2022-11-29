using IVCRM.API.IntegrationTests.TestData.Entities;
using IVCRM.API.IntegrationTests.TestData.ViewModels;
using IVCRM.API.ViewModels;
using System.Net;

namespace IVCRM.API.IntegrationTests.ApiTests
{
    public class ProductControllerTests : IntegrationTestsBase
    {
        [Fact]
        public async void Create_ViewModel_ReturnsViewModel()
        {
            //Arrange
            var viewModel = TestProductViewModels.ValidProductViewModel;
            var entity = TestProductEntities.ProductEntity;

            using var request = new HttpRequestMessage(HttpMethod.Post, $"/api/product");
            request.AddContent(TestProductViewModels.ValidChangeProductViewModel);

            //Act
            var actualResult = await Client.SendAsync(request);
            var responseResult = actualResult.GetResponseResult<ProductViewModel>();

            entity.Id = responseResult.Id;
            viewModel.Id = responseResult.Id;

            //Assert
            actualResult.StatusCode.Should().Be(HttpStatusCode.OK);
            responseResult.Should().BeEquivalentTo(viewModel);
            Context.Products.Last().Should().BeEquivalentTo(entity);
        }

        [Fact]
        public async void Create_ViewModelNotValid_ReturnsNotFound()
        {
            //Arrange
            var unchangedCollectionCount = Context.Products.Count();

            using var request = new HttpRequestMessage(HttpMethod.Post, $"/api/product");
            request.AddContent(new ChangeProductViewModel());

            //Act
            var actualResult = await Client.SendAsync(request);

            //Assert
            actualResult.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            Context.Products.Count().Should().Be(unchangedCollectionCount);
        }

        [Fact]
        public async Task GetAll_DataExists_ReturnsViewModelCollection()
        {
            //Arrange
            var entityCollection = TestProductEntities.ProductEntityCollection;
            var viewModelCollection = TestProductViewModels.ValidProductViewModelCollection;
            var entitiesCount = entityCollection.Count;

            await AddRangeToContext(entityCollection);

            using var request = new HttpRequestMessage(HttpMethod.Get, $"/api/product");

            //Act
            var actualResult = await Client.SendAsync(request);
            var responseResult = actualResult.GetResponseResult<IEnumerable<ProductViewModel>>();

            //Assert
            actualResult.StatusCode.Should().Be(HttpStatusCode.OK);
            responseResult.TakeLast(entitiesCount).Should().BeEquivalentTo(viewModelCollection, opt => opt.Excluding(x => x.Id));
        }

        [Fact]
        public async Task GetById_WhenDataExists_ShouldViewModel()
        {
            //Arrange
            var entity = TestProductEntities.ProductEntity;
            var id = await AddToContext(entity);
            var viewModel = TestProductViewModels.ValidProductViewModel;
            viewModel.Id = id;

            using var request = new HttpRequestMessage(HttpMethod.Get, $"/api/product/{id}");

            //Act
            var actualResult = await Client.SendAsync(request);
            var responseResult = actualResult.GetResponseResult<ProductViewModel>();

            //Assert
            actualResult.StatusCode.Should().Be(HttpStatusCode.OK);
            responseResult.Should().BeEquivalentTo(viewModel);
        }

        [Fact]
        public async void Update_ViewModel_ReturnsViewModel()
        {
            //Arrange
            var entity = TestProductEntities.ProductEntity;
            var id = await AddToContext(entity);
            var expectedEntity = TestProductEntities.UpdatedProductEntity;
            var expectedViewModel = TestProductViewModels.UpdatedProductViewModel;
            expectedViewModel.Id = id;
            expectedEntity.Id = id;

            using var request = new HttpRequestMessage(HttpMethod.Put, $"/api/product/{id}");
            request.AddContent(TestProductViewModels.UpdatedChangeProductViewModel);

            //Act
            var actualResult = await Client.SendAsync(request);
            var responseResult = actualResult.GetResponseResult<ProductViewModel>();
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
            using var request = new HttpRequestMessage(HttpMethod.Put, $"/api/product/{id}");
            request.AddContent(new ChangeProductViewModel());

            //Act
            var actualResult = await Client.SendAsync(request);

            //Assert
            actualResult.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async void Delete_Id_DeletesEntityWithSameId()
        {
            //Arrange
            var entity = TestProductEntities.ProductEntity;
            var id = await AddToContext(entity);

            using var request = new HttpRequestMessage(HttpMethod.Delete, $"/api/product/{id}");

            //Act
            var actualResult = await Client.SendAsync(request);

            //Assert
            actualResult.StatusCode.Should().Be(HttpStatusCode.OK);
            Context.Products.Should().NotContain(entity);
        }
    }
}
