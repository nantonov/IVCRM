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
    }
}
