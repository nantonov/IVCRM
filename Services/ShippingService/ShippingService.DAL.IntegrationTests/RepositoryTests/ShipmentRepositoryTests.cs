using MongoDB.Driver;
using ShippingService.DAL.IntegrationTests.Infrastructure;
using ShippingService.DAL.IntegrationTests.TestData.Entities;
using ShippingService.DAL.Repositories;
using ShippingService.DAL.Repositories.Interfaces;

namespace ShippingService.DAL.IntegrationTests.RepositoryTests
{
    public class ShipmentRepositoryTests : IntegrationTestsBase
    {
        private readonly IShipmentRepository _repository;

        public ShipmentRepositoryTests()
        {
            _repository = new ShipmentRepository(Context);

            AssertionOptions.AssertEquivalencyUsing(options => options
                .Using<DateTime>(ctx => ctx.Subject.Should().BeWithin(TimeSpan.FromMilliseconds(1000))).WhenTypeIs<DateTime>()
            );
        }

        [Fact]
        public async Task Create_ValidEntity_ReturnsEntity()
        {
            //Arrange
            var entity = TestShipmentEntities.ValidShipmentEntity;

            //Act
            var actualResult = await _repository.Create(entity);

            //Assert
            actualResult.Should().BeEquivalentTo(entity);
            ShipmentCollection.Find(x => x.Id == actualResult.Id).Single().Should().BeEquivalentTo(entity);
        }

        [Fact]
        public async Task GetByOrderId_EntityExists_ReturnsEntity()
        {
            //Arrange
            var entity = TestShipmentEntities.ValidShipmentEntity;
            await AddToContext(entity);

            //Act
            var actualResult = await _repository.GetByOrderId(entity.OrderId);

            //Assert
            actualResult.Should().BeEquivalentTo(entity);
        }
    }
}
