using IVCRM.BLL.Exceptions;
using IVCRM.BLL.Models;
using IVCRM.BLL.Services;
using IVCRM.BLL.UnitTests.TestData.Entities;
using IVCRM.DAL.Entities;
using IVCRM.DAL.Repositories.Interfaces;
using Moq;
using Moq.AutoMock;

namespace IVCRM.BLL.UnitTests.ServiceTests
{
    public class ProductCategoryServiceTests
    {
        [Fact]
        public async void Create_Model_ReturnsModel()
        {
            //Arrange
            var model = TestProductCategoryModels.ProductCategoryModel;
            var entity = TestProductCategoryEntities.ProductCategoryEntity;

            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            mocker.Setup<IProductCategoryRepository, Task<ProductCategoryEntity>>(x => x.Create(It.IsAny<ProductCategoryEntity>()))
                .ReturnsAsync(entity);
            mocker.Setup<IMapper, ProductCategory>(x => x.Map<ProductCategory>(entity)).Returns(model);

            var service = mocker.CreateInstance<ProductCategoryService>();

            //Act
            var response = await service.Create(model);

            //Assert
            mocker.GetMock<IProductCategoryRepository>().Verify(x => x.Create(It.IsAny<ProductCategoryEntity>()), Times.Once);
            response.ShouldBeEquivalentTo(model);
        }

        [Fact]
        public void GetAll_DataExists_ReturnsModelCollection()
        {
            //Arrange
            var models = TestProductCategoryModels.ProductCategoryModelCollection;
            var entities = TestProductCategoryEntities.ProductCategoryEntityCollection;

            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            mocker.Setup<IProductCategoryRepository, IEnumerable<ProductCategoryEntity>>(x => x.GetAll())
                .Returns(entities);
            mocker.Setup<IMapper, IEnumerable<ProductCategory>>(x => x.Map<IEnumerable<ProductCategory>>(entities)).Returns(models);

            var service = mocker.CreateInstance<ProductCategoryService>();

            //Act
            var response = service.GetAll();

            //Assert
            mocker.GetMock<IProductCategoryRepository>().Verify(x => x.GetAll(), Times.Once);
            response.ShouldBeEquivalentTo(models);
        }

        [Fact]
        public async void GetById_Id_ReturnsModel()
        {
            //Arrange
            var model = TestProductCategoryModels.ProductCategoryModel;
            var entity = TestProductCategoryEntities.ProductCategoryEntity;
            var id = model.Id;

            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            mocker.Setup<IProductCategoryRepository, Task<ProductCategoryEntity?>>(x => x.GetById(It.IsAny<int>()))
                .ReturnsAsync(entity);
            mocker.Setup<IMapper, ProductCategory>(x => x.Map<ProductCategory>(entity)).Returns(model);

            var service = mocker.CreateInstance<ProductCategoryService>();

            //Act
            var response = await service.GetById(id);

            //Assert
            mocker.GetMock<IProductCategoryRepository>().Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
            response.ShouldBeEquivalentTo(model);
        }

        [Fact]
        public async void Update_Model_ReturnsModel()
        {
            //Arrange
            var model = TestProductCategoryModels.ProductCategoryModel;
            var entity = TestProductCategoryEntities.ProductCategoryEntity;

            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            mocker.Setup<IProductCategoryRepository, Task<ProductCategoryEntity?>>(x => x.Update(It.IsAny<ProductCategoryEntity>()))
                .ReturnsAsync(entity);
            mocker.Setup<IMapper, ProductCategory>(x => x.Map<ProductCategory>(entity)).Returns(model);

            var service = mocker.CreateInstance<ProductCategoryService>();

            //Act
            var response = await service.Update(model);

            //Assert
            mocker.GetMock<IProductCategoryRepository>().Verify(x => x.Update(It.IsAny<ProductCategoryEntity>()), Times.Once);
            response.ShouldBeEquivalentTo(model);
        }
        
        [Fact]
        public async void Update_EntityNotExists_ThrowsResourceNotFoundException()
        {
            //Arrange
            var model = TestProductCategoryModels.ProductCategoryModel;
            var entity = TestProductCategoryEntities.ProductCategoryEntity;

            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            mocker.Setup<IProductCategoryRepository, Task<ProductCategoryEntity?>>(x => x.GetById(It.IsAny<int>()))
                .Returns(Task.FromResult((ProductCategoryEntity)null!)!);
            mocker.Setup<IMapper, ProductCategory>(x => x.Map<ProductCategory>(entity)).Returns(model);

            var service = mocker.CreateInstance<ProductCategoryService>();

            //Act
            Func<Task<ProductCategory?>> update = async () => await service.Update(model);

            //Assert
            await update.ShouldThrowAsync<ResourceNotFoundException>();
            mocker.GetMock<IProductCategoryRepository>().Verify(x => x.Update(It.IsAny<ProductCategoryEntity>()), Times.Never);
        }

        [Fact]
        public async void Delete_Id_ReturnsModel()
        {
            //Arrange
            var model = TestProductCategoryModels.ProductCategoryModel;
            var entity = TestProductCategoryEntities.ProductCategoryEntity;
            var id = model.Id;

            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            mocker.Setup<IMapper, ProductCategory>(x => x.Map<ProductCategory>(entity)).Returns(model);

            var service = mocker.CreateInstance<ProductCategoryService>();

            //Act
            await service.Delete(id);

            //Assert
            mocker.GetMock<IProductCategoryRepository>().Verify(x => x.Delete(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async void Delete_EntityNotExists_ThrowsResourceNotFoundException()
        {
            //Arrange
            var model = TestProductCategoryModels.ProductCategoryModel;
            var entity = TestProductCategoryEntities.ProductCategoryEntity;
            var id = model.Id;

            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            mocker.Setup<IProductCategoryRepository, Task<ProductCategoryEntity?>>(x => x.GetById(It.IsAny<int>()))
                .Returns(Task.FromResult((ProductCategoryEntity)null!)!);

            var service = mocker.CreateInstance<ProductCategoryService>();

            //Act
            Func<Task> update = async () => await service.Delete(id);

            //Assert
            await update.ShouldThrowAsync<ResourceNotFoundException>();
            mocker.GetMock<IProductCategoryRepository>().Verify(x => x.Delete(It.IsAny<int>()), Times.Never);
        }
    }
}