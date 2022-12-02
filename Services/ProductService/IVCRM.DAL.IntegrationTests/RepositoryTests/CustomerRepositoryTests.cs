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
            actualResult.ShouldBeEquivalentTo(entity);
            Context.Customers.Last().ShouldBeEquivalentTo(entity);
        }

        [Fact]
        public async Task GetAll_DataExists_ReturnsEntityCollection()
        {
            //Arrange
            var entities = TestCustomerEntities.CustomerEntityCollection;
            await AddRangeToContext(entities);
            //Act
            var actualResult = await _customerRepository.GetAll();

            //Assert
            actualResult.ShouldNotBeEmpty();
            entities.ShouldBeSubsetOf(actualResult);
        }

        [Fact]
        public async Task GetById_EntityExists_ReturnsEntity()
        {
            //Arrange
            var entity = TestCustomerEntities.CustomerEntity;
            await AddToContext(entity);

            //Act
            var actualResult = await _customerRepository.GetById(entity.Id);

            //Assert
            actualResult.ShouldBeEquivalentTo(entity);
        }

        [Fact]
        public async Task Update_EntityExists_UpdateAndReturnsEntity()
        {
            //Arrange
            var entity = TestCustomerEntities.CustomerEntity;
            var updatedEntity = TestCustomerEntities.UpdatedCustomerEntity;
            await AddToContext(entity);
            
            entity.FirstName = updatedEntity.FirstName;

            //Act
            var actualResult = await _customerRepository.Update(entity);

            //Assert
            actualResult.ShouldBeEquivalentTo(entity);
        }

        [Fact]
        public async Task Delete_EntityExists_DeletesEntity()
        {
            //Arrange
            var entity = TestCustomerEntities.CustomerEntity;
            await AddToContext(TestCustomerEntities.CustomerEntity);

            //Act
            await _customerRepository.Delete(entity.Id);

            //Assert
            Context.Customers.ShouldNotContain(entity);
        }

        [Fact]
        public async Task Delete_EntityNotExists_Returns()
        {
            //Arrange
            await AddToContext(TestCustomerEntities.CustomerEntity);
            var entitiesCount = Context.Customers.Count();
            var unreachableId = int.MaxValue;

            //Act
            await _customerRepository.Delete(unreachableId);

            //Assert
            Context.Customers.Count().ShouldBe(entitiesCount);
        }
    }
}
