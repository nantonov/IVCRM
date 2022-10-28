using IVCRM.BLL.Models;
using IVCRM.DAL.Entities;

namespace IVCRM.IntegrationTests.TestData.Models
{
    internal static class TestCustomerEntities
    {
        internal static CustomerEntity CustomerEntity => new()
        {
            FirstName = "FirstName",
            LastName = "LastName",
            PhoneNumber = "Number",
        };

        internal static List<CustomerEntity> CustomerEntityCollection => new ()
        {
            CustomerEntity,
        };
    }
}
