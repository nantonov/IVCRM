using FluentAssertions;
using MongoDB.Driver;
using ShippingService.API.IntegrationTests.Infrastructure;
using ShippingService.API.IntegrationTests.Infrastructure.Extensions;
using ShippingService.API.IntegrationTests.TestData.Entities;
using ShippingService.API.IntegrationTests.TestData.ViewModels;
using ShippingService.API.ViewModels;
using System.Net;

namespace ShippingService.API.IntegrationTests.ApiTests
{
    public class ShipmentControllerTests : IntegrationTestsBase
    {
        public ShipmentControllerTests()
        {
            AssertionOptions.AssertEquivalencyUsing(options => options
                .Using<DateTime>(ctx => ctx.Subject.Should().BeWithin(TimeSpan.FromMilliseconds(1000))).WhenTypeIs<DateTime>()
            );
        }

        [Fact]
        public async void Create_ValidViewModel_ReturnsViewModel()
        {
            //Arrange
            var viewModel = TestShipmentViewModels.ValidShipmentViewModel;
            var entity = TestShipmentEntities.ValidShipmentEntity;

            using var request = new HttpRequestMessage(HttpMethod.Post, $"/api/shipment");
            request.AddContent(TestShipmentViewModels.ValidChangeShipmentViewModel);

            //Act
            var actualResult = await Client.SendAsync(request);
            var responseResult = actualResult.GetResponseResult<ShipmentViewModel>();

            entity.Id = responseResult.Id;
            entity.CreatedDate = responseResult.CreatedDate;
            viewModel.Id = responseResult.Id;
            viewModel.CreatedDate = responseResult.CreatedDate;

            //Assert
            actualResult.StatusCode.Should().Be(HttpStatusCode.OK);
            responseResult.CreatedDate.Should().NotBe(default);
            responseResult.Should().BeEquivalentTo(viewModel);
            ShipmentCollection.Find(x => x.Id == responseResult.Id).Single().Should().BeEquivalentTo(entity);
        }
        
        [Fact]
        public async void Create_ViewModelNotValid_ReturnsNotFound()
        {
            //Arrange
            var unchangedCollectionCount = await ShipmentCollection.Find(_ => true).CountDocumentsAsync();

            using var request = new HttpRequestMessage(HttpMethod.Post, $"/api/shipment");
            request.AddContent(TestShipmentViewModels.InvalidShipmentViewModel);

            //Act
            var actualResult = await Client.SendAsync(request);
            var responseResult = actualResult.GetResponseResult<ShipmentViewModel>();

            //Assert
            actualResult.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            ShipmentCollection.Find(_ => true).CountDocuments().Should().Be(unchangedCollectionCount);
        }

        [Fact]
        public async Task GetByOrderId_DataExists_ReturnsViewModel()
        {
            //Arrange
            var entity = TestShipmentEntities.ValidShipmentEntity;
            var id = await AddToContext(entity);
            var viewModel = TestShipmentViewModels.ValidShipmentViewModel;
            viewModel.Id = id;

            using var request = new HttpRequestMessage(HttpMethod.Get, $"/api/shipment/orders/{entity.OrderId}");

            //Act
            var actualResult = await Client.SendAsync(request);
            var responseResult = actualResult.GetResponseResult<ShipmentViewModel>();

            //Assert
            actualResult.StatusCode.Should().Be(HttpStatusCode.OK);
            responseResult.Should().BeEquivalentTo(viewModel);
        }
    }
}
