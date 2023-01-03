using IVCRM.Core;
using IVCRM.DAL.Entities;

namespace IVCRM.TestData.Entities
{
    public static class TestCustomerEntities
    {
        public static CustomerEntity CustomerEntity => new()
        {
            FirstName = "FirstName",
            LastName = "LastName",
            Email = "Email",
            PhoneNumber = "+1234567",
        };

        public static CustomerEntity UpdatedCustomerEntity => new()
        {
            FirstName = "UpdatedFirstName",
            LastName = "UpdatedLastName",
            Email = "Email",
            PhoneNumber = "+1234567",
        };

        public static List<CustomerEntity> CustomerEntityCollection => new ()
        {
            CustomerEntity,
        };

        public static PagedList<CustomerEntity> PaginatedEntityCollection => new()
        {
            PageSize = 10,
            CurrentPage = 0,
            TotalCount = 1,
            TotalPages = 1,
            Data = CustomerEntityCollection,
        };
    }
}
