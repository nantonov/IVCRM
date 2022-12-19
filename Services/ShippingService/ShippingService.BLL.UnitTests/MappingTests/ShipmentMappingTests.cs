using IVCRM.BLL.UnitTests.TestData.ViewModels;
using ShippingService.API.Profiles;
using ShippingService.BLL.Handlers.Commands;
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
            var model = TestShipmentModels.ValidShipmentModel;
            var entity = TestShipmentEntities.ValidShipmentEntity;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<BllMappingProfile>());
            var mapper = config.CreateMapper();

            //Act
            var result = mapper.Map<Shipment>(entity);

            //Assert
            result.ShouldBeEquivalentTo(model);
        }

        [Fact]
        public void Map_Model_ReturnsEntity()
        {
            //Arrange
            var model = TestShipmentModels.ValidShipmentModel;
            var entity = TestShipmentEntities.ValidShipmentEntity;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<BllMappingProfile>());
            var mapper = config.CreateMapper();

            //Act
            var result = mapper.Map<ShipmentEntity>(model);

            //Assert
            result.ShouldBeEquivalentTo(entity);
        }

        [Fact]
        public void Map_CreateShipmentCommand_ReturnsModel()
        {
            //Arrange
            var model = TestShipmentModels.ValidShipmentModel;
            var command = TestShipmentCommands.ValidCreateShipmentCommand;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<BllMappingProfile>());
            var mapper = config.CreateMapper();

            //Act
            var result = mapper.Map<Shipment>(command);
            result.Id = model.Id;

            //Assert
            result.ShouldBeEquivalentTo(model);
        }

        [Fact]
        public void Map_CreateShipmentViewModel_ReturnsCreateShipmentCommand()
        {
            //Arrange
            var viewModel = TestShipmentViewModels.ValidChangeShipmentViewModel;
            var command = TestShipmentCommands.ValidCreateShipmentCommand;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<ApiMappingProfile>());
            var mapper = config.CreateMapper();

            //Act
            var result = mapper.Map<CreateShipmentCommand>(viewModel);

            //Assert
            result.ShouldBeEquivalentTo(command);
        }
    }
}