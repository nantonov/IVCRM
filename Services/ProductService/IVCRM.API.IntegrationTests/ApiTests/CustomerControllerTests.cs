using IVCRM.API.IntegrationTests.TestData.Entities;
using IVCRM.API.IntegrationTests.TestData.ViewModels;
using IVCRM.API.ViewModels;
using System.Net;

namespace IVCRM.API.IntegrationTests.ApiTests
{
    public class CustomerControllerTests : IntegrationTestsBase
    {
        [Fact]
        public async void Create_ValidViewModel_ReturnsViewModel()
        {
            //Arrange
            var viewModel = TestCustomerViewModels.ValidCustomerViewModel;
            var entity = TestCustomerEntities.CustomerEntity;

            using var request = new HttpRequestMessage(HttpMethod.Post, $"/api/customer");
            request.AddContent(TestCustomerViewModels.ValidChangeCustomerViewModel);

            //Act
            var actualResult = await Client.SendAsync(request);
            var responseResult = actualResult.GetResponseResult<CustomerViewModel>();

            entity.Id = responseResult.Id;
            viewModel.Id = responseResult.Id;

            //Assert
            actualResult.StatusCode.ShouldBe(HttpStatusCode.OK);
            responseResult.ShouldBeEquivalentTo(viewModel);
            Context.Customers.Last().ShouldBeEquivalentTo(entity);
        }

        [Fact]
        public async void Create_InvalidViewModel_ReturnsBadRequest()
        {
            //Arrange
            var unchangedCollectionCount = Context.Customers.Count();

            using var request = new HttpRequestMessage(HttpMethod.Post, $"/api/customer");
            request.AddContent(new ChangeCustomerViewModel());

            //Act
            var actualResult = await Client.SendAsync(request);

            //Assert
            actualResult.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
            Context.Customers.Count().ShouldBe(unchangedCollectionCount);
        }

        [Fact]
        public async Task GetAll_DataExists_ReturnsViewModelCollection()
        {
            //Arrange
            var entityCollection = TestCustomerEntities.CustomerEntityCollection;
            var viewModelCollection = TestCustomerViewModels.ValidCustomerViewModelCollection;
            var entitiesCount = entityCollection.Count;

            await AddRangeToContext(entityCollection);

            using var request = new HttpRequestMessage(HttpMethod.Get, $"/api/customer");

            //Act
            var actualResult = await Client.SendAsync(request);
            var responseResult = actualResult.GetResponseResult<IEnumerable<CustomerViewModel>>();
            viewModelCollection.Select(x => x.Id = responseResult.First(z => z.FullName == x.FullName).Id).ToList();

            //Assert
            actualResult.StatusCode.ShouldBe(HttpStatusCode.OK);
            responseResult.TakeLast(entitiesCount).ToList().ShouldBeEquivalentTo(viewModelCollection);
        }

        [Fact]
        public async Task GetById_DataExists_ReturnsViewModel()
        {
            //Arrange
            var entity = TestCustomerEntities.CustomerEntity;
            var id = await AddToContext(entity);
            var viewModel = TestCustomerViewModels.ValidCustomerViewModel;
            viewModel.Id = id;

            using var request = new HttpRequestMessage(HttpMethod.Get, $"/api/customer/{id}");

            //Act
            var actualResult = await Client.SendAsync(request);
            var responseResult = actualResult.GetResponseResult<CustomerViewModel>();

            //Assert
            actualResult.StatusCode.ShouldBe(HttpStatusCode.OK);
            responseResult.ShouldBeEquivalentTo(viewModel);
        }

        [Fact]
        public async void Update_ValidViewModel_ReturnsViewModel()
        {
            //Arrange
            var entity = TestCustomerEntities.CustomerEntity;
            var id = await AddToContext(entity);
            var expectedEntity = TestCustomerEntities.UpdatedCustomerEntity;
            var expectedViewModel = TestCustomerViewModels.UpdatedCustomerViewModel;
            expectedViewModel.Id = id;
            expectedEntity.Id = id;

            using var request = new HttpRequestMessage(HttpMethod.Put, $"/api/customer/{id}");
            request.AddContent(TestCustomerViewModels.UpdatedChangeCustomerViewModel);

            //Act
            var actualResult = await Client.SendAsync(request);
            var responseResult = actualResult.GetResponseResult<CustomerViewModel>();
            Context.Entry(entity).Reload();

            //Assert
            actualResult.StatusCode.ShouldBe(HttpStatusCode.OK);
            responseResult.ShouldBeEquivalentTo(expectedViewModel);
            entity.ShouldBeEquivalentTo(expectedEntity);
        }

        [Fact]
        public async void Update_InvalidViewModel_ReturnsBadRequest()
        {
            //Arrange
            var id = 1;
            using var request = new HttpRequestMessage(HttpMethod.Put, $"/api/customer/{id}");
            request.AddContent(new ChangeCustomerViewModel());

            //Act
            var actualResult = await Client.SendAsync(request);

            //Assert
            actualResult.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async void Delete_ValidId_DeletesEntity()
        {
            //Arrange
            var entity = TestCustomerEntities.CustomerEntity;
            var id = await AddToContext(entity);

            using var request = new HttpRequestMessage(HttpMethod.Delete, $"/api/customer/{id}");

            //Act
            var actualResult = await Client.SendAsync(request);

            //Assert
            actualResult.StatusCode.ShouldBe(HttpStatusCode.OK);
            Context.Customers.ShouldNotContain(entity);
        }
    }
}
