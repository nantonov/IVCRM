using ShippingService.BLL.Models;
using ShippingService.BLL.Profiles;
using ShippingService.BLL.UnitTests.TestData.Commands;
using ShippingService.BLL.UnitTests.TestData.Entities;
using ShippingService.DAL.Entities;

namespace ShippingService.BLL.UnitTests.MappingTests
{
    public class ShipmentMappingTests
    {
        [Fact]
        public void Map_Entity_ReturnsModel()
        {
            //Arrange
            var model = TestShipmentModels.Shipment;
            var entity = TestShipmentEntities.ShipmentEntity;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<BllMappingProfile>());
            var mapper = config.CreateMapper();

            //Act
            var result = mapper.Map<Shipment>(entity);

            //Assert
            result.Should().BeEquivalentTo(model);
        }

        [Fact]
        public void Map_Model_ReturnsEntity()
        {
            //Arrange
            var model = TestShipmentModels.Shipment;
            var entity = TestShipmentEntities.ShipmentEntity;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<BllMappingProfile>());
            var mapper = config.CreateMapper();

            //Act
            var result = mapper.Map<ShipmentEntity>(model);

            //Assert
            result.Should().BeEquivalentTo(entity);
        }

        [Fact]
        public void Map_CreateShipmentCommand_ReturnsModel()
        {
            //Arrange
            var model = TestShipmentModels.Shipment;
            var command = TestShipmentCommands.CreateShipmentCommand;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<BllMappingProfile>());
            var mapper = config.CreateMapper();

            //Act
            var result = mapper.Map<Shipment>(command);

            //Assert
            result.Should().BeEquivalentTo(model, options => options.Excluding(x => x.Id));
        }
    }
}