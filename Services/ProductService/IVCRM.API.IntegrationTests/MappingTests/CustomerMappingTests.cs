using AutoMapper;
using IVCRM.API.IntegrationTests.TestData.ViewModels;
using IVCRM.API.Profiles;
using IVCRM.API.ViewModels;
using IVCRM.BLL.Models;

namespace IVCRM.API.IntegrationTests.MappingTests
{
    public class CustomerMappingTests
    {
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
            result.Should().BeEquivalentTo(viewModel);
        }

        [Fact]
        public void Map_ChangeCustomerViewModel_ReturnsModel()
        {
            //Arrange 
            var model = TestCustomerViewModels.ValidChangeCustomerViewModel;
            var entity = TestCustomerModels.CustomerModel;

            var config = new MapperConfiguration(cfg => cfg.AddProfile<ApiMappingProfile>());
            var mapper = config.CreateMapper();

            //Act 
            var result = mapper.Map<Customer>(entity);

            //Assert 
            result.Should().BeEquivalentTo(model);

        }
    }
}
