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
    public class ProductServiceTests
    {
        [Fact]
        public async void Create_Model_ReturnsModel()
        {
            //Arrange
            var model = TestProductModels.ProductModel;
            var entity = TestProductEntities.ProductEntity;

            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            mocker.Setup<IProductRepository, Task<ProductEntity>>(x => x.Create(It.IsAny<ProductEntity>()))
                .ReturnsAsync(entity);
            mocker.Setup<IMapper, Product>(x => x.Map<Product>(entity)).Returns(model);

            var service = mocker.CreateInstance<ProductService>();

            //Act
            var response = await service.Create(model);

            //Assert
            mocker.GetMock<IProductRepository>().Verify(x => x.Create(It.IsAny<ProductEntity>()), Times.Once);
            response.ShouldBeEquivalentTo(model);
        }

        [Fact]
        public async void GetAll_DataExists_ReturnsModelCollection()
        {
            //Arrange
            var models = TestProductModels.ProductModelCollection;
            var entities = TestProductEntities.ProductEntityCollection;

            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            mocker.Setup<IProductRepository, Task<IEnumerable<ProductEntity>>>(x => x.GetAll())
                .ReturnsAsync(entities);
            mocker.Setup<IMapper, IEnumerable<Product>>(x => x.Map<IEnumerable<Product>>(entities)).Returns(models);

            var service = mocker.CreateInstance<ProductService>();

            //Act
            var response = await service.GetAll();

            //Assert
            mocker.GetMock<IProductRepository>().Verify(x => x.GetAll(), Times.Once);
            response.ShouldBeEquivalentTo(models);
        }

        [Fact]
        public async void GetById_Id_ReturnsModel()
        {
            //Arrange
            var model = TestProductModels.ProductModel;
            var entity = TestProductEntities.ProductEntity;
            var id = model.Id;

            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            mocker.Setup<IProductRepository, Task<ProductEntity?>>(x => x.GetById(It.IsAny<int>()))
                .ReturnsAsync(entity);
            mocker.Setup<IMapper, Product>(x => x.Map<Product>(entity)).Returns(model);

            var service = mocker.CreateInstance<ProductService>();

            //Act
            var response = await service.GetById(id);

            //Assert
            mocker.GetMock<IProductRepository>().Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
            response.ShouldBeEquivalentTo(model);
        }

        [Fact]
        public async void Update_Model_ReturnsModel()
        {
            //Arrange
            var model = TestProductModels.ProductModel;
            var entity = TestProductEntities.ProductEntity;

            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            mocker.Setup<IProductRepository, Task<ProductEntity?>>(x => x.Update(It.IsAny<ProductEntity>()))
                .ReturnsAsync(entity);
            mocker.Setup<IMapper, Product>(x => x.Map<Product>(entity)).Returns(model);

            var service = mocker.CreateInstance<ProductService>();

            //Act
            var response = await service.Update(model);

            //Assert
            mocker.GetMock<IProductRepository>().Verify(x => x.Update(It.IsAny<ProductEntity>()), Times.Once);
            response.ShouldBeEquivalentTo(model);
        }
        
        [Fact]
        public async void Update_EntityNotExists_ThrowsResourceNotFoundException()
        {
            //Arrange
            var model = TestProductModels.ProductModel;
            var entity = TestProductEntities.ProductEntity;

            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            mocker.Setup<IProductRepository, Task<ProductEntity?>>(x => x.GetById(It.IsAny<int>()))
                .Returns(Task.FromResult((ProductEntity)null!)!);
            mocker.Setup<IMapper, Product>(x => x.Map<Product>(entity)).Returns(model);

            var service = mocker.CreateInstance<ProductService>();

            //Act
            Func<Task<Product?>> update = async () => await service.Update(model);

            //Assert
            await update.ShouldThrowAsync<ResourceNotFoundException>();
            mocker.GetMock<IProductRepository>().Verify(x => x.Update(It.IsAny<ProductEntity>()), Times.Never);
        }

        [Fact]
        public async void Delete_Id_ReturnsModel()
        {
            //Arrange
            var model = TestProductModels.ProductModel;
            var entity = TestProductEntities.ProductEntity;
            var id = model.Id;

            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            mocker.Setup<IMapper, Product>(x => x.Map<Product>(entity)).Returns(model);

            var service = mocker.CreateInstance<ProductService>();

            //Act
            await service.Delete(id);

            //Assert
            mocker.GetMock<IProductRepository>().Verify(x => x.Delete(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async void Delete_EntityNotExists_ThrowsResourceNotFoundException()
        {
            //Arrange
            var model = TestProductModels.ProductModel;
            var entity = TestProductEntities.ProductEntity;
            var id = model.Id;

            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            mocker.Setup<IProductRepository, Task<ProductEntity?>>(x => x.GetById(It.IsAny<int>()))
                .Returns(Task.FromResult((ProductEntity)null!)!);

            var service = mocker.CreateInstance<ProductService>();

            //Act
            Func<Task> update = async () => await service.Delete(id);

            //Assert
            await update.ShouldThrowAsync<ResourceNotFoundException>();
            mocker.GetMock<IProductRepository>().Verify(x => x.Delete(It.IsAny<int>()), Times.Never);
        }
    }
}