using IVCRM.BLL.Models;
using IVCRM.BLL.Services;
using IVCRM.BLL.UnitTests.TestData.Entities;
using IVCRM.DAL.Entities;
using IVCRM.DAL.Repositories.Interfaces;
using Moq;
using Moq.AutoMock;

namespace IVCRM.BLL.UnitTests.ServiceTests
{
    public class CustomerServiceTests
    {
        [Fact]
        public async void Create_Model_ReturnsModel()
        {
            //Arrange
            var model = TestCustomers.Customer;
            var entity = TestCustomerEntities.CustomerEntity;

            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            mocker.Setup<ICustomerRepository, Task<CustomerEntity>>(x => x.Create(It.IsAny<CustomerEntity>()))
                .ReturnsAsync(entity);
            mocker.Setup<IMapper, Customer>(x => x.Map<Customer>(entity)).Returns(model);

            var service = mocker.CreateInstance<CustomerService>();

            //Act
            var response = await service.Create(model);

            //Assert
            mocker.GetMock<ICustomerRepository>().Verify(x => x.Create(It.IsAny<CustomerEntity>()));
            response.Should().BeEquivalentTo(model);
        }

        [Fact]
        public async void GetAll_DataExists_ReturnsModelCollection()
        {
            //Arrange
            var models = TestCustomers.CustomerCollection;
            var entities = TestCustomerEntities.CustomerEntityCollection;

            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            mocker.Setup<ICustomerRepository, Task<IEnumerable<CustomerEntity>>>(x => x.GetAll())
                .ReturnsAsync(entities);
            mocker.Setup<IMapper, IEnumerable<Customer>>(x => x.Map<IEnumerable<Customer>>(entities)).Returns(models);

            var service = mocker.CreateInstance<CustomerService>();

            //Act
            var response = await service.GetAll();

            //Assert
            mocker.GetMock<ICustomerRepository>().Verify(x => x.GetAll());
            response.Should().BeEquivalentTo(models);
        }

        [Fact]
        public async void GetById_Id_ReturnsModel()
        {
            //Arrange
            var model = TestCustomers.Customer;
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
            mocker.GetMock<ICustomerRepository>().Verify(x => x.GetById(It.IsAny<int>()));
            response.Should().BeEquivalentTo(model);
        }

        [Fact]
        public async void Update_Model_ReturnsModel()
        {
            //Arrange
            var model = TestCustomers.Customer;
            var entity = TestCustomerEntities.CustomerEntity;

            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            mocker.Setup<ICustomerRepository, Task<CustomerEntity?>>(x => x.Update(It.IsAny<CustomerEntity>()))
                .ReturnsAsync(entity);
            mocker.Setup<IMapper, Customer>(x => x.Map<Customer>(entity)).Returns(model);

            var service = mocker.CreateInstance<CustomerService>();

            //Act
            var response = await service.Update(model);

            //Assert
            mocker.GetMock<ICustomerRepository>().Verify(x => x.Update(It.IsAny<CustomerEntity>()));
            response.Should().BeEquivalentTo(model);
        }

        [Fact]
        public async void Delete_Id_ReturnsModel()
        {
            //Arrange
            var model = TestCustomers.Customer;
            var entity = TestCustomerEntities.CustomerEntity;
            var id = model.Id;

            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            mocker.Setup<IMapper, Customer>(x => x.Map<Customer>(entity)).Returns(model);

            var service = mocker.CreateInstance<CustomerService>();

            //Act
            await service.Delete(id);

            //Assert
            mocker.GetMock<ICustomerRepository>().Verify(x => x.Delete(It.IsAny<int>()));
        }
    }
}