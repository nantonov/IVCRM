using IVCRM.Core;
using IVCRM.DAL.Entities;
using IVCRM.DAL.integrationTests.TestData.Entities;

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

        internal static List<CustomerEntity> CustomerEntityCollection => new ()
        {
            CustomerEntity,
        };

        internal static PagedList<CustomerEntity> PaginatedEntityCollection => new()
        {
            PageSize = 10,
            CurrentPage = 0,
            TotalCount = 1,
            TotalPages = 1,
            Data = CustomerEntityCollection,
        };
    }
}
