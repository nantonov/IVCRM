using IVCRM.DAL.Entities;

namespace IVCRM.API.IntegrationTests.TestData.Entities
{
    internal static class TestCustomerEntities
    {
        internal static CustomerEntity CustomerEntity => new()
        {
            FirstName = "FirstName",
            LastName = "LastName",
            PhoneNumber = "+1234567",
        };

        internal static CustomerEntity UpdatedCustomerEntity => new()
        {
            FirstName = "UpdatedFirstName",
            LastName = "UpdatedLastName",
            PhoneNumber = "+1234567",
        };

        internal static List<CustomerEntity> CustomerEntityCollection => new()
        {
            new ()
            {
                FirstName = "FirstName1",
                LastName = "LastName1",
                PhoneNumber = "+1234567",
            },
            new ()
            {
                FirstName = "FirstName2",
                LastName = "LastName2",
                PhoneNumber = "+2234567",
            },
            new ()
            {
                FirstName = "FirstName3",
                LastName = "LastName3",
                PhoneNumber = "+3234567",
            },
        };
    }
}
