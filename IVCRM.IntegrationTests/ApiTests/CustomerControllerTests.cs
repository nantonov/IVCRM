using IVCRM.API.ViewModels;
using System.Net;

namespace IVCRM.IntegrationTests.ApiTests
{
    public class CustomerControllerTests : ApiIntegrationTestsBase
    {
        [Fact]
        public async void Create_WhenViewModelIsProvided_ShouldCreateEntityAndReturnModel()
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
