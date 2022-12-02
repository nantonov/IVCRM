using IVCRM.BLL.Exceptions;
using IVCRM.BLL.Models;
using IVCRM.BLL.Services;
using IVCRM.BLL.UnitTests.TestData.Entities;
using IVCRM.DAL.Entities;
using IVCRM.DAL.Repositories.Interfaces;
using Moq;
using Moq.AutoMock;

namespace IVCRM.BLL.UnitTests.ServiceTests
{
    public class OrderServiceTests
    {
        [Fact]
        public async void Create_Model_ReturnsModel()
        {
            //Arrange
            var model = TestOrderModels.OrderModel;
            var entity = TestOrderEntities.OrderEntity;

            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            mocker.Setup<IOrderRepository, Task<OrderEntity>>(x => x.Create(It.IsAny<OrderEntity>()))
                .ReturnsAsync(entity);
            mocker.Setup<IMapper, Order>(x => x.Map<Order>(entity)).Returns(model);

            var service = mocker.CreateInstance<OrderService>();

            //Act
            var response = await service.Create(model);

            //Assert
            mocker.GetMock<IOrderRepository>().Verify(x => x.Create(It.IsAny<OrderEntity>()), Times.Once);
            response.ShouldBeEquivalentTo(model);
        }

        [Fact]
        public async void GetAll_DataExists_ReturnsModelCollection()
        {
            //Arrange
            var models = TestOrderModels.OrderModelCollection;
            var entities = TestOrderEntities.OrderEntityCollection;

            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            mocker.Setup<IOrderRepository, Task<IEnumerable<OrderEntity>>>(x => x.GetAll())
                .ReturnsAsync(entities);
            mocker.Setup<IMapper, IEnumerable<Order>>(x => x.Map<IEnumerable<Order>>(entities)).Returns(models);

            var service = mocker.CreateInstance<OrderService>();

            //Act
            var response = await service.GetAll();

            //Assert
            mocker.GetMock<IOrderRepository>().Verify(x => x.GetAll(), Times.Once);
            response.ShouldBeEquivalentTo(models);
        }

        [Fact]
        public async void GetById_Id_ReturnsModel()
        {
            //Arrange
            var model = TestOrderModels.OrderModel;
            var entity = TestOrderEntities.OrderEntity;
            var id = model.Id;

            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            mocker.Setup<IOrderRepository, Task<OrderEntity?>>(x => x.GetById(It.IsAny<int>()))
                .ReturnsAsync(entity);
            mocker.Setup<IMapper, Order>(x => x.Map<Order>(entity)).Returns(model);

            var service = mocker.CreateInstance<OrderService>();

            //Act
            var response = await service.GetById(id);

            //Assert
            mocker.GetMock<IOrderRepository>().Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
            response.ShouldBeEquivalentTo(model);
        }

        [Fact]
        public async void Update_Model_ReturnsModel()
        {
            //Arrange
            var model = TestOrderModels.OrderModel;
            var entity = TestOrderEntities.OrderEntity;

            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            mocker.Setup<IOrderRepository, Task<OrderEntity?>>(x => x.Update(It.IsAny<OrderEntity>()))
                .ReturnsAsync(entity);
            mocker.Setup<IMapper, Order>(x => x.Map<Order>(entity)).Returns(model);

            var service = mocker.CreateInstance<OrderService>();

            //Act
            var response = await service.Update(model);

            //Assert
            mocker.GetMock<IOrderRepository>().Verify(x => x.Update(It.IsAny<OrderEntity>()), Times.Once);
            response.ShouldBeEquivalentTo(model);
        }
        
        [Fact]
        public async void Update_EntityNotExists_ThrowsResourceNotFoundException()
        {
            //Arrange
            var model = TestOrderModels.OrderModel;
            var entity = TestOrderEntities.OrderEntity;

            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            mocker.Setup<IOrderRepository, Task<OrderEntity?>>(x => x.GetById(It.IsAny<int>()))
                .Returns(Task.FromResult((OrderEntity)null!)!);
            mocker.Setup<IMapper, Order>(x => x.Map<Order>(entity)).Returns(model);

            var service = mocker.CreateInstance<OrderService>();

            //Act
            Func<Task<Order?>> update = async () => await service.Update(model);

            //Assert
            await update.ShouldThrowAsync<ResourceNotFoundException>();
            mocker.GetMock<IOrderRepository>().Verify(x => x.Update(It.IsAny<OrderEntity>()), Times.Never);
        }

        [Fact]
        public async void Delete_Id_ReturnsModel()
        {
            //Arrange
            var model = TestOrderModels.OrderModel;
            var entity = TestOrderEntities.OrderEntity;
            var id = model.Id;

            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            mocker.Setup<IMapper, Order>(x => x.Map<Order>(entity)).Returns(model);

            var service = mocker.CreateInstance<OrderService>();

            //Act
            await service.Delete(id);

            //Assert
            mocker.GetMock<IOrderRepository>().Verify(x => x.Delete(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async void Delete_EntityNotExists_ThrowsResourceNotFoundException()
        {
            //Arrange
            var model = TestOrderModels.OrderModel;
            var entity = TestOrderEntities.OrderEntity;
            var id = model.Id;

            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            mocker.Setup<IOrderRepository, Task<OrderEntity?>>(x => x.GetById(It.IsAny<int>()))
                .Returns(Task.FromResult((OrderEntity)null!)!);

            var service = mocker.CreateInstance<OrderService>();

            //Act
            Func<Task> update = async () => await service.Delete(id);

            //Assert
            await update.ShouldThrowAsync<ResourceNotFoundException>();
            mocker.GetMock<IOrderRepository>().Verify(x => x.Delete(It.IsAny<int>()), Times.Never);
        }
    }
}