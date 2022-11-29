using IVCRM.BLL.Models;
using IVCRM.DAL.Entities;

namespace IVCRM.API.IntegrationTests.TestData.Models
{
    internal static class TestCustomerModels
    {
        internal static Customer CustomerModel => new()
        {
            Id = 1,
            FirstName = "FirstName",
            LastName = "LastName",
            PhoneNumber = "+1234567",
        };

        internal static List<Customer> CustomerModelCollection => new()
        {
            CustomerModel,
        };
    }
}
