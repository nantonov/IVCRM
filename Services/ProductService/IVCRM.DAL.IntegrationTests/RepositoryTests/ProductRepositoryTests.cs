using IVCRM.DAL.IntegrationTests.TestData.Entities;
using IVCRM.DAL.Repositories;
using IVCRM.DAL.Repositories.Interfaces;

namespace IVCRM.DAL.IntegrationTests.RepositoryTests
{
    public class ProductRepositoryTests : IntegrationTestsBase
    {
        private readonly IProductRepository _repository;

        public ProductRepositoryTests()
        {
            _repository = new ProductRepository(Context);
        }

        [Fact]
        public async Task Create_Entity_ReturnsEntity()
        {
            //Arrange
            var entity = TestProductEntities.ProductEntity;

            //Act
            var actualResult = await _repository.Create(entity);

            //Assert
            actualResult.Should().BeEquivalentTo(entity);
            Context.Products.Last().Should().BeEquivalentTo(entity);
        }

        [Fact]
        public async Task GetAll_DataExists_ReturnsEntityCollection()
        {
            //Arrange
            var entities = TestProductEntities.ProductEntityCollection;
            await AddRangeToContext(entities);
            //Act
            var actualResult = await _repository.GetAll();

            //Assert
            actualResult.Should().NotBeEmpty();
            actualResult.Should().Contain(entities);
        }

        [Fact]
        public async Task GetById_EntityExists_ReturnsEntity()
        {
            //Arrange
            var entity = TestProductEntities.ProductEntity;
            await AddToContext(entity);

            //Act
            var actualResult = await _repository.GetById(entity.Id);

            //Assert
            actualResult.Should().BeEquivalentTo(entity);
        }

        [Fact]
        public async Task Update_EntityExists_UpdateAndReturnsEntity()
        {
            //Arrange
            var entity = TestProductEntities.ProductEntity;
            var updatedEntity = TestProductEntities.UpdatedProductEntity;
            await AddToContext(entity);
            
            entity.Name = updatedEntity.Name;

            //Act
            var actualResult = await _repository.Update(entity);

            //Assert
            actualResult.Should().BeEquivalentTo(entity);
        }

        [Fact]
        public async Task Delete_EntityExists_DeletesEntity()
        {
            //Arrange
            var entity = TestProductEntities.ProductEntity;
            await AddToContext(TestProductEntities.ProductEntity);

            //Act
            await _repository.Delete(entity.Id);

            //Assert
            Context.Products.Should().NotContain(entity);
        }

        [Fact]
        public async Task Delete_EntityNotExists_Returns()
        {
            //Arrange
            await AddToContext(TestProductEntities.ProductEntity);
            var entitiesCount = Context.Products.Count();
            var unreachableId = int.MaxValue;

            //Act
            await _repository.Delete(unreachableId);

            //Assert
            Context.Products.Count().Should().Be(entitiesCount);
        }
    }
}
