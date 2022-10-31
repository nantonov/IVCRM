using IVCRM.API.IntegrationTests.TestData.Entities;
using IVCRM.API.IntegrationTests.TestData.ViewModels;
using IVCRM.API.ViewModels;
using System.Net;

namespace IVCRM.API.IntegrationTests.ApiTests
{
    public class CustomerControllerTests : IntegrationTestsBase
    {
        [Fact]
        public async void Create_ViewModel_ReturnsViewModel()
        {
            //Arrange
            var viewModel = TestCustomerViewModels.CustomerViewModel;
            var entity = TestCustomerEntities.CustomerEntity;

            using var request = new HttpRequestMessage(HttpMethod.Post, $"/api/customer");
            request.AddContent(TestCustomerViewModels.ChangeCustomerViewModel);

            //Act
            var actualResult = await Client.SendAsync(request);
            var responseResult = actualResult.GetResponseResult<CustomerViewModel>();

            entity.Id = responseResult.Id;
            viewModel.Id = responseResult.Id;

            //Assert
            actualResult.StatusCode.Should().Be(HttpStatusCode.OK);
            responseResult.Should().BeEquivalentTo(viewModel);
            Context.Customers.Last().Should().BeEquivalentTo(entity);
        }

        [Fact]
        public async void Create_ViewModelNotValid_ReturnsNotFound()
        {
            //Arrange
            var unchangedCollectionCount = Context.Customers.Count();

            using var request = new HttpRequestMessage(HttpMethod.Post, $"/api/customer");
            request.AddContent(new ChangeCustomerViewModel());

            //Act
            var actualResult = await Client.SendAsync(request);
            var responseResult = actualResult.GetResponseResult<CustomerViewModel>();

            //Assert
            actualResult.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            Context.Customers.Count().Should().Be(unchangedCollectionCount);
        }

        [Fact]
        public async Task GetAll_DataExists_ReturnsViewModelCollection()
        {
            //Arrange
            var entityCollection = TestCustomerEntities.CustomerEntityCollection;
            var viewModelCollection = TestCustomerViewModels.CustomerViewModelCollection;
            var entitiesCount = entityCollection.Count;

            await AddRangeToContext(entityCollection);

            using var request = new HttpRequestMessage(HttpMethod.Get, $"/api/customer");

            //Act
            var actualResult = await Client.SendAsync(request);
            var responseResult = actualResult.GetResponseResult<IEnumerable<CustomerViewModel>>();

            //Assert
            actualResult.StatusCode.Should().Be(HttpStatusCode.OK);
            responseResult.TakeLast(entitiesCount).Should().BeEquivalentTo(viewModelCollection, opt => opt.Excluding(x => x.Id));
        }

        [Fact]
        public async Task GetById_WhenDataExists_ShouldViewModel()
        {
            //Arrange
            var entity = TestCustomerEntities.CustomerEntity;
            var id = await AddToContext(entity);
            var viewModel = TestCustomerViewModels.CustomerViewModel;
            viewModel.Id = id;

            using var request = new HttpRequestMessage(HttpMethod.Get, $"/api/customer/{id}");

            //Act
            var actualResult = await Client.SendAsync(request);
            var responseResult = actualResult.GetResponseResult<CustomerViewModel>();

            //Assert
            actualResult.StatusCode.Should().Be(HttpStatusCode.OK);
            responseResult.Should().BeEquivalentTo(viewModel);
        }

        [Fact]
        public async void Update_ViewModel_ReturnsViewModel()
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
            actualResult.StatusCode.Should().Be(HttpStatusCode.OK);
            responseResult.Should().BeEquivalentTo(expectedViewModel);
            entity.Should().BeEquivalentTo(expectedEntity);
        }

        [Fact]
        public async void Update_ViewModelNotValid_ReturnsNotFound()
        {
            //Arrange
            var id = 1;
            using var request = new HttpRequestMessage(HttpMethod.Put, $"/api/customer/{id}");
            request.AddContent(new ChangeCustomerViewModel());

            //Act
            var actualResult = await Client.SendAsync(request);
            var responseResult = actualResult.GetResponseResult<CustomerViewModel>();

            //Assert
            actualResult.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async void Delete_Id_DeletesEntityWithSameId()
        {
            //Arrange
            var entity = TestCustomerEntities.CustomerEntity;
            var id = await AddToContext(entity);

            using var request = new HttpRequestMessage(HttpMethod.Delete, $"/api/customer/{id}");

            //Act
            var actualResult = await Client.SendAsync(request);

            //Assert
            actualResult.StatusCode.Should().Be(HttpStatusCode.OK);
            Context.Customers.Should().NotContain(entity);
        }
    }
}
