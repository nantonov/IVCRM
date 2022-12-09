using IVCRM.DAL.Entities;

namespace IVCRM.DAL.IntegrationTests.TestData.Entities
{
    internal static class TestCustomerEntities
    {
        internal static CustomerEntity CustomerEntity => new()
        {
            FirstName = "FirstName",
            LastName = "LastName",
            Email = "Email",
            PhoneNumber = "+1234567",
        };

        internal static CustomerEntity UpdatedCustomerEntity => new()
        {
            FirstName = "UpdatedFirstName",
            LastName = "UpdatedLastName",
            Email = "Email",
            PhoneNumber = "+1234567",
        };

        internal static List<CustomerEntity> CustomerEntityCollection => new ()
        {
            CustomerEntity,
        };
    }
}
