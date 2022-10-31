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

        [Fact]
        public async Task GetAll_IfEntitiesExists_ShouldEntityCollection()
        {
            //Arrange
            var entities = TestCustomerEntities.CustomerEntityCollection;
            await AddRangeToContext(entities);
            //Act
            var actualResult = await _customerRepository.GetAll();

            //Assert
            actualResult.Should().NotBeEmpty();
            actualResult.Should().Contain(entities);
        }

        [Fact]
        public async Task GetById_IfEntityExists_ShouldReturnEntity()
        {
            //Arrange
            var entity = TestCustomerEntities.CustomerEntity;
            await AddToContext(entity);

            //Act
            var actualResult = await _customerRepository.GetById(entity.Id);

            //Assert
            actualResult.Should().BeEquivalentTo(entity);
        }

        [Fact]
        public async Task Update_IfEntityExists_ShouldUpdateAndReturnEntity()
        {
            //Arrange
            var entity = TestCustomerEntities.CustomerEntity;
            await AddToContext(entity);
            var updatedEntity = TestCustomerEntities.CustomerEntityCollection.First();
            entity.FirstName = updatedEntity.FirstName;

            //Act
            var actualResult = await _customerRepository.Update(entity);

            //Assert
            actualResult.Should().BeEquivalentTo(entity);
        }

        [Fact]
        public async Task Delete_IfEntityExists_ShouldDeleteAndReturnEntity()
        {
            //Arrange
            var entity = TestCustomerEntities.CustomerEntity;
            await AddToContext(TestCustomerEntities.CustomerEntity);

            //Act
            await _customerRepository.Delete(entity.Id);

            //Assert
            Context.Customers.Should().NotContain(entity);
        }
    }
}
