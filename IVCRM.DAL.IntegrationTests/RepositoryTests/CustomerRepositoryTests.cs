using IVCRM.DAL.IntegrationTests.TestData.Entities;
using IVCRM.DAL.Repositories;
using IVCRM.DAL.Repositories.Interfaces;

namespace IVCRM.DAL.IntegrationTests.RepositoryTests
{
    public class CustomerRepositoryTests : IntegrationTestsBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerRepositoryTests()
        {
            _customerRepository = new CustomerRepository(Context);
        }

        [Fact]
        public async Task Create_Entity_ReturnsEntity()
        {

            //Arrange
            var entity = TestCustomerEntities.CustomerEntity;

            //Act
            var actualResult = await _customerRepository.Create(entity);

            //Assert
            actualResult.Should().BeEquivalentTo(entity);
            Context.Customers.Last().Should().BeEquivalentTo(entity);
        }
    }
}
