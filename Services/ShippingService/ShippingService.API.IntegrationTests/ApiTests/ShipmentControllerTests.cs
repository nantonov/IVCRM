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
            actualResult.StatusCode.ShouldBe(HttpStatusCode.OK);
            responseResult.CreatedDate.ShouldNotBe(default);
            responseResult.ShouldBeEquivalentTo(viewModel);
            ShipmentCollection.Find(x => x.Id == responseResult.Id).Single().ShouldNotBeNull();
        }
        
        [Fact]
        public async void Create_InvalidViewModel_ReturnsBadRequest()
        {
            //Arrange
            var unchangedCollectionCount = await ShipmentCollection.Find(_ => true).CountDocumentsAsync();

            using var request = new HttpRequestMessage(HttpMethod.Post, $"/api/shipment");
            request.AddContent(TestShipmentViewModels.InvalidShipmentViewModel);

            //Act
            var actualResult = await Client.SendAsync(request);
            var responseResult = actualResult.GetResponseResult<ShipmentViewModel>();

            //Assert
            actualResult.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
            ShipmentCollection.Find(_ => true).CountDocuments().ShouldBe(unchangedCollectionCount);
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
            actualResult.StatusCode.ShouldBe(HttpStatusCode.OK);
            responseResult.ShouldBeEquivalentTo(viewModel);
        }
    }
}
