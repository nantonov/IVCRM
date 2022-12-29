using IVCRM.Core.Models;
using IVCRM.DAL.IntegrationTests.TestData.Entities;
using IVCRM.DAL.Repositories;
using IVCRM.DAL.Repositories.Interfaces;

namespace IVCRM.DAL.IntegrationTests.RepositoryTests
{
    public class CustomerRepositoryTests : IntegrationTestsBase
    {
        private readonly ICustomerRepository _repository;

        public CustomerRepositoryTests()
        {
            _repository = new CustomerRepository(Context);
        }

        [Fact]
        public async Task Create_Entity_ReturnsEntity()
        {
            //Arrange
            var entity = TestCustomerEntities.CustomerEntity;

            //Act
            var actualResult = await _repository.Create(entity);

            //Assert
            actualResult.ShouldBeEquivalentTo(entity);
            Context.Customers.Last().ShouldBeEquivalentTo(entity);
        }

        [Fact]
        public async Task GetAll_DataExists_ReturnsEntityCollection()
        {
            //Arrange
            var entities = TestCustomerEntities.CustomerEntityCollection;
            var request = new TableParameters { PageNumber = 0, PageSize = 10 };
            await AddRangeToContext(entities);
            //Act
            var actualResult = await _repository.GetAll(request);

            //Assert
            actualResult.Data.ShouldNotBeEmpty();
            entities.ShouldBeSubsetOf(actualResult.Data);
        }

        [Fact]
        public async Task GetById_EntityExists_ReturnsEntity()
        {
            //Arrange
            var entity = TestCustomerEntities.CustomerEntity;
            await AddToContext(entity);

            //Act
            var actualResult = await _repository.GetById(entity.Id);

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
            var actualResult = await _repository.Update(entity);

            //Assert
            actualResult.ShouldBeEquivalentTo(entity);
        }

        [Fact]
        public async Task Delete_ValidId_DeletesEntity()
        {
            //Arrange
            var entity = TestCustomerEntities.CustomerEntity;
            await AddToContext(TestCustomerEntities.CustomerEntity);

            //Act
            await _repository.Delete(entity.Id);

            //Assert
            Context.Customers.ShouldNotContain(entity);
        }

        [Fact]
        public async Task Delete_InvalidId_Returns()
        {
            //Arrange
            await AddToContext(TestCustomerEntities.CustomerEntity);
            var entitiesCount = Context.Customers.Count();
            var unreachableId = int.MaxValue;

            //Act
            await _repository.Delete(unreachableId);

            //Assert
            Context.Customers.Count().ShouldBe(entitiesCount);
        }
    }
}
