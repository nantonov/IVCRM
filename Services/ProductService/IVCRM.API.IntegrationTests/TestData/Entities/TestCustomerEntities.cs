using IVCRM.DAL.Entities;

namespace IVCRM.API.IntegrationTests.TestData.Entities
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

        internal static CustomerEntity CustomerDetailsModel => new()
        {
            FirstName = "FirstName",
            LastName = "LastName",
            Email = "Email",
            PhoneNumber = "+1234567",
            DateOfBirth = DateTime.MaxValue,
            Address = TestAddressEntities.AddressEntity,
            Orders = TestOrderEntities.OrderEntityCollection,
        };

        internal static CustomerEntity UpdatedCustomerEntity => new()
        {
            FirstName = "UpdatedFirstName",
            LastName = "UpdatedLastName",
            Email = "Email",
            PhoneNumber = "+1234567",
        };

        internal static List<CustomerEntity> CustomerEntityCollection => new()
        {
            new ()
            {
                FirstName = "FirstName1",
                LastName = "LastName1",
                Email = "Email",
                PhoneNumber = "+1234567",
            },
            new ()
            {
                FirstName = "FirstName2",
                LastName = "LastName2",
                Email = "Email",
                PhoneNumber = "+2234567",
            },
            new ()
            {
                FirstName = "FirstName3",
                LastName = "LastName3",
                Email = "Email",
                PhoneNumber = "+3234567",
            },
        };
    }
}
