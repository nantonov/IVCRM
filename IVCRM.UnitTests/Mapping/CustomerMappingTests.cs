using IVCRM.API.Profiles;
using IVCRM.API.ViewModels;
using IVCRM.BLL.Models;
using IVCRM.BLL.Profiles;
using IVCRM.DAL.Entities;

namespace IVCRM.UnitTests.Controllers
{
    public class CustomerMappingTests
    {
        [Fact]
        public void Map_WhenEntityIsProvided_ShouldReturnModel()
        {
            //Arrange
            var model = TestCustomers.Customer;
            var entity = TestCustomerEntities.CustomerEntity;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<BllMappingProfile>());
            var mapper = config.CreateMapper();

            //Act
            var result = mapper.Map<Customer>(entity);

            //Assert
            result.Should().BeEquivalentTo(model);
        }

        [Fact]
        public void Map_WhenModelIsProvided_ShouldReturnEntity()
        {
            //Arrange
            var model = TestCustomers.Customer;
            var entity = TestCustomerEntities.CustomerEntity;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<BllMappingProfile>());
            var mapper = config.CreateMapper();

            //Act
            var result = mapper.Map<CustomerEntity>(model);

            //Assert
            result.Should().BeEquivalentTo(entity);
        }

        [Fact]
        public void Map_WhenModelIsProvided_ShouldReturnViewModel()
        {
            //Arrange
            var model = TestCustomers.Customer;
            var viewModel = TestCustomerViewModels.CustomerViewModel;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<ApiMappingProfile>());
            var mapper = config.CreateMapper();

            //Act
            var result = mapper.Map<CustomerViewModel>(model);

            //Assert
            result.Should().BeEquivalentTo(viewModel);
        }
    }
}