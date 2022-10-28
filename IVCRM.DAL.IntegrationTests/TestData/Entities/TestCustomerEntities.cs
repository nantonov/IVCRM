using IVCRM.DAL.Entities;

namespace IVCRM.DAL.IntegrationTests.TestData.Models
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
