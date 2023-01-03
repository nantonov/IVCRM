using IVCRM.BLL.Exceptions;
using IVCRM.BLL.Models;
using IVCRM.BLL.Services;
using IVCRM.TestData.Entities;
using IVCRM.Core;
using IVCRM.Core.Models;
using IVCRM.DAL.Entities;
using IVCRM.DAL.Repositories.Interfaces;
using IVCRM.TestData.Models;
using Moq;
using Moq.AutoMock;

namespace IVCRM.BLL.UnitTests.ServiceTests
{
    public class CustomerServiceTests
    {
        [Fact]
        public async Task Create_Model_ReturnsModel()
        {
            //Arrange
            var model = TestCustomerModels.CustomerModel;
            var entity = TestCustomerEntities.CustomerEntity;

            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            mocker.Setup<ICustomerRepository, Task<CustomerEntity>>(x => x.Create(It.IsAny<CustomerEntity>()))
                .ReturnsAsync(entity);
            mocker.Setup<IMapper, Customer>(x => x.Map<Customer>(entity)).Returns(model);

            var service = mocker.CreateInstance<CustomerService>();

            //Act
            var response = await service.Create(model);

            //Assert
            mocker.GetMock<ICustomerRepository>().Verify(x => x.Create(It.IsAny<CustomerEntity>()), Times.Once);
            response.ShouldBeEquivalentTo(model);
        }

        [Fact]
        public async Task GetAll_DataExists_ReturnsModelCollection()
        {
            //Arrange
            var models = TestCustomerModels.PaginatedModelCollection;
            var entities = TestCustomerEntities.PaginatedEntityCollection;
            var request = new TableParameters {PageNumber = 1, PageSize = 10};

            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            mocker.Setup<ICustomerRepository, Task<PagedList<CustomerEntity>>>(x => x.GetAll(request))
                .ReturnsAsync(entities);
            mocker.Setup<IMapper, PagedList<Customer>>(x => x.Map<PagedList<Customer>>(entities)).Returns(models);

            var service = mocker.CreateInstance<CustomerService>();

            //Act
            var response = await service.GetAll(request);

            //Assert
            mocker.GetMock<ICustomerRepository>().Verify(x => x.GetAll(request), Times.Once);
            response.ShouldBeEquivalentTo(models);
        }

        [Fact]
        public async Task GetById_Id_ReturnsModel()
        {
            //Arrange
            var model = TestCustomerModels.CustomerModel;
            var entity = TestCustomerEntities.CustomerEntity;
            var id = model.Id;

            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            mocker.Setup<ICustomerRepository, Task<CustomerEntity?>>(x => x.GetById(It.IsAny<int>()))
                .ReturnsAsync(entity);
            mocker.Setup<IMapper, Customer>(x => x.Map<Customer>(entity)).Returns(model);

            var service = mocker.CreateInstance<CustomerService>();

            //Act
            var response = await service.GetById(id);

            //Assert
            mocker.GetMock<ICustomerRepository>().Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
            response.ShouldBeEquivalentTo(model);
        }

        [Fact]
        public async Task Update_Model_ReturnsModel()
        {
            //Arrange
            var model = TestCustomerModels.CustomerModel;
            var entity = TestCustomerEntities.CustomerEntity;

            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            mocker.Setup<ICustomerRepository, Task<CustomerEntity?>>(x => x.Update(It.IsAny<CustomerEntity>()))
                .ReturnsAsync(entity);
            mocker.Setup<IMapper, Customer>(x => x.Map<Customer>(entity)).Returns(model);

            var service = mocker.CreateInstance<CustomerService>();

            //Act
            var response = await service.Update(model);

            //Assert
            mocker.GetMock<ICustomerRepository>().Verify(x => x.Update(It.IsAny<CustomerEntity>()), Times.Once);
            response.ShouldBeEquivalentTo(model);
        }
        
        [Fact]
        public async Task Update_InvalidModel_ThrowsResourceNotFoundException()
        {
            //Arrange
            var model = TestCustomerModels.CustomerModel;
            var entity = TestCustomerEntities.CustomerEntity;

            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            mocker.Setup<ICustomerRepository, Task<CustomerEntity?>>(x => x.GetById(It.IsAny<int>()))
                .Returns(Task.FromResult((CustomerEntity)null!)!);
            mocker.Setup<IMapper, Customer>(x => x.Map<Customer>(entity)).Returns(model);

            var service = mocker.CreateInstance<CustomerService>();

            //Act
            Func<Task<Customer?>> update = async () => await service.Update(model);

            //Assert
            await update.ShouldThrowAsync<ResourceNotFoundException>();
            mocker.GetMock<ICustomerRepository>().Verify(x => x.Update(It.IsAny<CustomerEntity>()), Times.Never);
        }

        [Fact]
        public async Task Delete_ValidId_DeletesEntity()
        {
            //Arrange
            var model = TestCustomerModels.CustomerModel;
            var entity = TestCustomerEntities.CustomerEntity;
            var id = model.Id;

            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            mocker.Setup<IMapper, Customer>(x => x.Map<Customer>(entity)).Returns(model);

            var service = mocker.CreateInstance<CustomerService>();

            //Act
            await service.Delete(id);

            //Assert
            mocker.GetMock<ICustomerRepository>().Verify(x => x.Delete(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task Delete_InvalidId_ThrowsResourceNotFoundException()
        {
            //Arrange
            var model = TestCustomerModels.CustomerModel;
            var id = model.Id;

            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            mocker.Setup<ICustomerRepository, Task<CustomerEntity?>>(x => x.GetById(It.IsAny<int>()))
                .Returns(Task.FromResult((CustomerEntity)null!)!);

            var service = mocker.CreateInstance<CustomerService>();

            //Act
            Func<Task> update = async () => await service.Delete(id);

            //Assert
            await update.ShouldThrowAsync<ResourceNotFoundException>();
            mocker.GetMock<ICustomerRepository>().Verify(x => x.Delete(It.IsAny<int>()), Times.Never);
        }
    }
}