using Moq;
using Moq.AutoMock;
using ShippingService.BLL.Models;
using ShippingService.BLL.Services;
using ShippingService.BLL.UnitTests.TestData.Entities;
using ShippingService.DAL.Entities;
using ShippingService.DAL.Repositories.Interfaces;

namespace SippingService.BLL.UnitTests.ServiceTests
{
    public class ShipmentServiceTests
    {
        [Fact]
        public async void Create_Model_ReturnsModel()
        {
            //Arrange
            var model = TestShipmentModels.Shipment;
            var entity = TestShipmentEntities.ShipmentEntity;

            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            mocker.Setup<IShipmentRepository, Task<ShipmentEntity>>(x => x.Create(It.IsAny<ShipmentEntity>()))
                .ReturnsAsync(entity);
            mocker.Setup<IMapper, Shipment>(x => x.Map<Shipment>(entity)).Returns(model);

            var service = mocker.CreateInstance<ShipmentService>();

            //Act
            var response = await service.Create(model);

            //Assert
            mocker.GetMock<IShipmentRepository>().Verify(x => x.Create(It.IsAny<ShipmentEntity>()), Times.Once);
            response.Should().BeEquivalentTo(model);
        }

        [Fact]
        public async void GetByOrderId_Id_ReturnsModel()
        {
            //Arrange
            var model = TestShipmentModels.Shipment;
            var entity = TestShipmentEntities.ShipmentEntity;
            var id = model.OrderId;

            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            mocker.Setup<IShipmentRepository, Task<ShipmentEntity?>>(x => x.GetByOrderId(It.IsAny<int>()))
                .ReturnsAsync(entity);
            mocker.Setup<IMapper, Shipment>(x => x.Map<Shipment>(entity)).Returns(model);

            var service = mocker.CreateInstance<ShipmentService>();

            //Act
            var response = await service.GetByOrderId(id);

            //Assert
            mocker.GetMock<IShipmentRepository>().Verify(x => x.GetByOrderId(It.IsAny<int>()), Times.Once);
            response.Should().BeEquivalentTo(model);
        }
    }
}