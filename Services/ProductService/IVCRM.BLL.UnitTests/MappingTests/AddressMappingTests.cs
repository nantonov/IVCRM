using IVCRM.API.Profiles;
using IVCRM.API.ViewModels;
using IVCRM.BLL.Models;
using IVCRM.BLL.Profiles;
using IVCRM.BLL.UnitTests.TestData.Entities;
using IVCRM.BLL.UnitTests.TestData.ViewModels;
using IVCRM.DAL.Entities;

namespace IVCRM.BLL.UnitTests.MappingTests
{
    public class AddressMappingTests
    {
        [Fact]
        public void Map_Entity_ReturnsModel()
        {
            //Arrange
            var model = TestAddressModels.AddressModel;
            var entity = TestAddressEntities.AddressEntity;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<BllMappingProfile>());
            var mapper = config.CreateMapper();

            //Act
            var result = mapper.Map<Address>(entity);

            //Assert
            result.ShouldBeEquivalentTo(model);
        }

        [Fact]
        public void Map_Model_ReturnsEntity()
        {
            //Arrange
            var model = TestAddressModels.AddressModel;
            var entity = TestAddressEntities.AddressEntity;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<BllMappingProfile>());
            var mapper = config.CreateMapper();

            //Act
            var result = mapper.Map<AddressEntity>(model);

            //Assert
            result.ShouldBeEquivalentTo(entity);
        }

        [Fact]
        public void Map_Model_ReturnsViewModel()
        {
            //Arrange 
            var model = TestAddressModels.AddressModel;
            var viewModel = TestAddressViewModels.ValidAddressViewModel;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<ApiMappingProfile>());
            var mapper = config.CreateMapper();

            //Act 
            var result = mapper.Map<AddressViewModel>(model);

            //Assert 
            result.ShouldBeEquivalentTo(viewModel);
        }

        [Fact]
        public void Map_ChangeViewModel_ReturnsModel()
        {
            //Arrange 
            var viewModel = TestAddressViewModels.ValidChangeAddressViewModel;
            var model = TestAddressModels.AddressModel;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<ApiMappingProfile>());
            var mapper = config.CreateMapper();

            //Act 
            var result = mapper.Map<Address>(viewModel);
            result.Id = model.Id;

            //Assert 
            result.ShouldBeEquivalentTo(model);

        }
    }
}