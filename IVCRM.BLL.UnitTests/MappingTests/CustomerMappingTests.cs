using IVCRM.API.Profiles;
using IVCRM.API.ViewModels;
using IVCRM.BLL.Models;
using IVCRM.BLL.Profiles;
using IVCRM.BLL.UnitTests.TestData.Entities;
using IVCRM.BLL.UnitTests.TestData.ViewModels;
using IVCRM.DAL.Entities;

namespace IVCRM.BLL.UnitTests.Mapping
{
    public class CustomerMappingTests
    {
        [Fact]
        public void Map_Entity_ReturnsModel()
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
        public void Map_Model_ReturnsEntity()
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
    }
}