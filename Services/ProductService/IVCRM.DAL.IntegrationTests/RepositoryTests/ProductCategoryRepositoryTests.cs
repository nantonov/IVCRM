using IVCRM.DAL.Entities;
using IVCRM.DAL.IntegrationTests.TestData.Entities;
using IVCRM.DAL.Repositories;
using IVCRM.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IVCRM.DAL.IntegrationTests.RepositoryTests
{
    public class ProductCategoryRepositoryTests : IntegrationTestsBase
    {
        private readonly IProductCategoryRepository _repository;

        public ProductCategoryRepositoryTests()
        {
            _repository = new ProductCategoryRepository(Context);
        }

        [Fact]
        public async Task Create_Entity_ReturnsEntity()
        {
            //Arrange
            var entity = TestProductCategoryEntities.ProductCategoryEntity;

            //Act
            var actualResult = await _repository.Create(entity);

            //Assert
            actualResult.Should().BeEquivalentTo(entity);
            Context.ProductCategories.Last().Should().BeEquivalentTo(entity);
        }

        [Fact]
        public async Task GetAll_DataExists_ReturnsOrderedEntityCollection()
        {
            //Arrange
            var parentId = await AddToContext(new ProductCategoryEntity() { Name = "Name1" });
            await AddToContext(new ProductCategoryEntity() { Name = "Name2", ParentCategoryId = parentId });

            var expectedResult = Context.ProductCategories.Include(x => x.ChildCategories).Last(x => x.ParentCategoryId == null);

            //Act
            var actualResult = _repository.GetAll();

            //Assert
            actualResult.Should().NotBeEmpty();
            actualResult.Should().Contain(expectedResult);
        }

        [Fact]
        public async Task GetById_EntityExists_ReturnsEntity()
        {
            //Arrange
            var entity = TestProductCategoryEntities.ProductCategoryEntity;
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
            var entity = TestProductCategoryEntities.ProductCategoryEntity;
            var updatedEntity = TestProductCategoryEntities.UpdatedProductCategoryEntity;
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
            var entity = TestProductCategoryEntities.ProductCategoryEntity;
            await AddToContext(TestProductCategoryEntities.ProductCategoryEntity);

            //Act
            await _repository.Delete(entity.Id);

            //Assert
            Context.ProductCategories.Should().NotContain(entity);
        }

        [Fact]
        public async Task Delete_EntityNotExists_Returns()
        {
            //Arrange
            await AddToContext(TestProductCategoryEntities.ProductCategoryEntity);
            var entitiesCount = Context.ProductCategories.Count();
            var unreachableId = int.MaxValue;

            //Act
            await _repository.Delete(unreachableId);

            //Assert
            Context.ProductCategories.Count().Should().Be(entitiesCount);
        }
    }
}
