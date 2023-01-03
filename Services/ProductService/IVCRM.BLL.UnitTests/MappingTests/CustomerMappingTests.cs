using IVCRM.API.Profiles;
using IVCRM.API.ViewModels;
using IVCRM.BLL.Models;
using IVCRM.BLL.Profiles;
using IVCRM.TestData.Entities;
using IVCRM.TestData.Models;
using IVCRM.TestData.ViewModels;
using IVCRM.DAL.Entities;

namespace IVCRM.BLL.UnitTests.MappingTests
{
    public class CustomerMappingTests
    {
        [Fact]
        public void Map_Entity_ReturnsModel()
        {
            //Arrange
            var model = TestCustomerModels.CustomerModel;
            var entity = TestCustomerEntities.CustomerEntity;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<BllMappingProfile>());
            var mapper = config.CreateMapper();

            //Act
            var result = mapper.Map<Customer>(entity);

            //Assert
            result.ShouldBeEquivalentTo(model);
        }

        [Fact]
        public void Map_Model_ReturnsEntity()
        {
            //Arrange
            var model = TestCustomerModels.CustomerModel;
            var entity = TestCustomerEntities.CustomerEntity;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<BllMappingProfile>());
            var mapper = config.CreateMapper();

            //Act
            var result = mapper.Map<CustomerEntity>(model);

            //Assert
            result.ShouldBeEquivalentTo(entity);
        }

        [Fact]
        public void Map_Model_ReturnsViewModel()
        {
            //Arrange 
            var model = TestCustomerModels.CustomerModel;
            var viewModel = TestCustomerViewModels.ValidCustomerViewModel;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<ApiMappingProfile>());
            var mapper = config.CreateMapper();

            //Act 
            var result = mapper.Map<CustomerViewModel>(model);

            //Assert 
            result.ShouldBeEquivalentTo(viewModel);
        }

        [Fact]
        public void Map_ChangeViewModel_ReturnsModel()
        {
            //Arrange 
            var viewModel = TestCustomerViewModels.ValidChangeCustomerViewModel;
            var model = TestCustomerModels.CustomerModel;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<ApiMappingProfile>());
            var mapper = config.CreateMapper();

            //Act 
            var result = mapper.Map<Customer>(viewModel);
            result.Id = model.Id;

            //Assert 
            result.ShouldBeEquivalentTo(model);

        }
    }
}