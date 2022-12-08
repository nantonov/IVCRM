using IVCRM.DAL.IntegrationTests.TestData.Entities;
using IVCRM.DAL.Repositories;
using IVCRM.DAL.Repositories.Interfaces;

namespace IVCRM.DAL.IntegrationTests.RepositoryTests
{
    public class OrderRepositoryTests : IntegrationTestsBase
    {
        private readonly IOrderRepository _repository;

        public OrderRepositoryTests()
        {
            _repository = new OrderRepository(Context);
        }

        [Fact]
        public async Task Create_Entity_ReturnsEntity()
        {
            //Arrange
            var entity = TestOrderEntities.OrderEntity;

            //Act
            var actualResult = await _repository.Create(entity);

            //Assert
            actualResult.ShouldBeEquivalentTo(entity);
            Context.Orders.Last().ShouldBeEquivalentTo(entity);
        }

        [Fact]
        public async Task GetAll_DataExists_ReturnsEntityCollection()
        {
            //Arrange
            var entities = TestOrderEntities.OrderEntityCollection;
            await AddRangeToContext(entities);
            //Act
            var actualResult = await _repository.GetAll();

            //Assert
            actualResult.ShouldNotBeEmpty();
            entities.ShouldBeSubsetOf(actualResult);
        }

        [Fact]
        public async Task GetById_EntityExists_ReturnsEntity()
        {
            //Arrange
            var entity = TestOrderEntities.OrderEntity;
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
            var entity = TestOrderEntities.OrderEntity;
            var updatedEntity = TestOrderEntities.UpdatedOrderEntity;
            await AddToContext(entity);
            
            entity.Name = updatedEntity.Name;
            entity.OrderStatus = updatedEntity.OrderStatus;

            //Act
            var actualResult = await _repository.Update(entity);

            //Assert
            actualResult.ShouldBeEquivalentTo(entity);
        }

        [Fact]
        public async Task Delete_ValidId_DeletesEntity()
        {
            //Arrange
            var entity = TestOrderEntities.OrderEntity;
            await AddToContext(TestOrderEntities.OrderEntity);

            //Act
            await _repository.Delete(entity.Id);

            //Assert
            Context.Orders.ShouldNotContain(entity);
        }

        [Fact]
        public async Task Delete_InvalidId_Returns()
        {
            //Arrange
            await AddToContext(TestOrderEntities.OrderEntity);
            var entitiesCount = Context.Orders.Count();
            var unreachableId = int.MaxValue;

            //Act
            await _repository.Delete(unreachableId);

            //Assert
            Context.Orders.Count().ShouldBe(entitiesCount);
        }
    }
}
