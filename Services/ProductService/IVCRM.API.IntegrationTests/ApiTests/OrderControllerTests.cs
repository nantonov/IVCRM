using System.Net;
using IVCRM.TestData.Entities;
using IVCRM.TestData.ViewModels;
using IVCRM.API.ViewModels;

namespace IVCRM.API.IntegrationTests.ApiTests
{
    public class OrderControllerTests : IntegrationTestsBase
    {
        [Fact]
        public async Task Create_ValidViewModel_ReturnsViewModel()
        {
            //Arrange
            var viewModel = TestOrderViewModels.ValidOrderViewModel;
            var requestModel = TestOrderViewModels.ValidChangeOrderViewModel;
            var customerId = await AddToContext(TestCustomerEntities.CustomerEntity);

            requestModel.CustomerId = customerId;
            viewModel.CustomerId = customerId;
            viewModel.OrderDate = requestModel.OrderDate;

            using var request = new HttpRequestMessage(HttpMethod.Post, $"/api/order");
            request.AddContent(requestModel);

            //Act
            var actualResult = await Client.SendAsync(request);
            var responseResult = actualResult.GetResponseResult<OrderViewModel>();

            viewModel.Id = responseResult.Id;

            //Assert
            actualResult.StatusCode.ShouldBe(HttpStatusCode.OK);
            responseResult.ShouldBeEquivalentTo(viewModel);
            Context.Orders.Last().Id.ShouldBeEquivalentTo(responseResult.Id);
        }

        [Fact]
        public async Task Create_InvalidViewModel_ReturnsBadRequest()
        {
            //Arrange
            var unchangedCollectionCount = Context.Orders.Count();

            using var request = new HttpRequestMessage(HttpMethod.Post, $"/api/order");
            request.AddContent(new ChangeOrderViewModel());

            //Act
            var actualResult = await Client.SendAsync(request);

            //Assert
            actualResult.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
            Context.Orders.Count().ShouldBe(unchangedCollectionCount);
        }

        [Fact]
        public async Task GetAll_DataExists_ReturnsViewModelCollection()
        {
            //Arrange
            var entityCollection = TestOrderEntities.OrderEntityCollection;
            var viewModelCollection = TestOrderViewModels.ValidOrderViewModelCollection;
            var entitiesCount = entityCollection.Count;

            await AddRangeToContext(entityCollection);

            using var request = new HttpRequestMessage(HttpMethod.Get, $"/api/order");

            //Act
            var actualResult = await Client.SendAsync(request);
            var responseResult = actualResult.GetResponseResult<IEnumerable<OrderViewModel>>();
            viewModelCollection.Select(x => x.Id = responseResult.Last(z => z.Name == x.Name).Id).ToList();

            //Assert
            actualResult.StatusCode.ShouldBe(HttpStatusCode.OK);
            responseResult.TakeLast(entitiesCount).ToList().ShouldBeEquivalentTo(viewModelCollection);
        }

        [Fact]
        public async Task GetById_DataExists_ReturnsViewModel()
        {
            //Arrange
            var entity = TestOrderEntities.OrderEntity;
            var id = await AddToContext(entity);
            var viewModel = TestOrderViewModels.ValidOrderViewModel;
            viewModel.Id = id;

            using var request = new HttpRequestMessage(HttpMethod.Get, $"/api/order/{id}");

            //Act
            var actualResult = await Client.SendAsync(request);
            var responseResult = actualResult.GetResponseResult<OrderViewModel>();

            //Assert
            actualResult.StatusCode.ShouldBe(HttpStatusCode.OK);
            responseResult.ShouldBeEquivalentTo(viewModel);
        }

        [Fact]
        public async Task Update_ValidViewModel_ReturnsViewModel()
        {
            //Arrange
            var entity = TestOrderEntities.OrderEntity;
            var id = await AddToContext(entity);
            var expectedViewModel = TestOrderViewModels.UpdatedOrderViewModel;
            var requestModel = TestOrderViewModels.UpdatedChangeOrderViewModel;
            var customerId = await AddToContext(TestCustomerEntities.CustomerEntity);

            requestModel.CustomerId = customerId;
            expectedViewModel.Id = id;
            expectedViewModel.CustomerId = customerId;
            expectedViewModel.OrderDate = requestModel.OrderDate;


            using var request = new HttpRequestMessage(HttpMethod.Put, $"/api/order/{id}");
            request.AddContent(requestModel);

            //Act
            var actualResult = await Client.SendAsync(request);
            var responseResult = actualResult.GetResponseResult<OrderViewModel>();

            //Assert
            actualResult.StatusCode.ShouldBe(HttpStatusCode.OK);
            responseResult.ShouldBeEquivalentTo(expectedViewModel);
        }

        [Fact]
        public async Task Update_InvalidViewModel_ReturnsBadRequest()
        {
            //Arrange
            var id = 1;
            using var request = new HttpRequestMessage(HttpMethod.Put, $"/api/order/{id}");
            request.AddContent(new ChangeOrderViewModel());

            //Act
            var actualResult = await Client.SendAsync(request);

            //Assert
            actualResult.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Delete_ValidId_DeletesEntity()
        {
            //Arrange
            var entity = TestOrderEntities.OrderEntity;
            var id = await AddToContext(entity);

            using var request = new HttpRequestMessage(HttpMethod.Delete, $"/api/order/{id}");

            //Act
            var actualResult = await Client.SendAsync(request);

            //Assert
            actualResult.StatusCode.ShouldBe(HttpStatusCode.OK);
            Context.Orders.ShouldNotContain(entity);
        }
    }
}
