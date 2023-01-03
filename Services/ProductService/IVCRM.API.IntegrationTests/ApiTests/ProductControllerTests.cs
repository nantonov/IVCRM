using System.Net;
using IVCRM.TestData.Entities;
using IVCRM.TestData.ViewModels;
using IVCRM.API.ViewModels;

namespace IVCRM.API.IntegrationTests.ApiTests
{
    public class ProductControllerTests : IntegrationTestsBase
    {
        [Fact]
        public async Task Create_ValidViewModel_ReturnsViewModel()
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
            actualResult.StatusCode.ShouldBe(HttpStatusCode.OK);
            responseResult.ShouldBeEquivalentTo(viewModel);
            Context.Products.Last().ShouldBeEquivalentTo(entity);
        }

        [Fact]
        public async Task Create_InvalidViewModel_ReturnsBadRequest()
        {
            //Arrange
            var unchangedCollectionCount = Context.Products.Count();

            using var request = new HttpRequestMessage(HttpMethod.Post, $"/api/product");
            request.AddContent(new ChangeProductViewModel());

            //Act
            var actualResult = await Client.SendAsync(request);

            //Assert
            actualResult.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
            Context.Products.Count().ShouldBe(unchangedCollectionCount);
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
            viewModelCollection.Select(x => x.Id = responseResult.Last(z => z.Name == x.Name).Id).ToList();

            //Assert
            actualResult.StatusCode.ShouldBe(HttpStatusCode.OK);
            responseResult.TakeLast(entitiesCount).ToList().ShouldBeEquivalentTo(viewModelCollection);
        }

        [Fact]
        public async Task GetById_DataExists_ReturnsViewModel()
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
            actualResult.StatusCode.ShouldBe(HttpStatusCode.OK);
            responseResult.ShouldBeEquivalentTo(viewModel);
        }

        [Fact]
        public async Task Update_ValidViewModel_ReturnsViewModel()
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
            actualResult.StatusCode.ShouldBe(HttpStatusCode.OK);
            responseResult.ShouldBeEquivalentTo(expectedViewModel);
            entity.ShouldBeEquivalentTo(expectedEntity);
        }

        [Fact]
        public async Task Update_InvalidViewModel_ReturnsBadRequest()
        {
            //Arrange
            var id = 1;
            using var request = new HttpRequestMessage(HttpMethod.Put, $"/api/product/{id}");
            request.AddContent(new ChangeProductViewModel());

            //Act
            var actualResult = await Client.SendAsync(request);

            //Assert
            actualResult.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Delete_ValidId_DeletesEntity()
        {
            //Arrange
            var entity = TestProductEntities.ProductEntity;
            var id = await AddToContext(entity);

            using var request = new HttpRequestMessage(HttpMethod.Delete, $"/api/product/{id}");

            //Act
            var actualResult = await Client.SendAsync(request);

            //Assert
            actualResult.StatusCode.ShouldBe(HttpStatusCode.OK);
            Context.Products.ShouldNotContain(entity);
        }
    }
}
