using IVCRM.DAL.Entities;

namespace IVCRM.BLL.UnitTests.TestData.Entities
{
    internal static class TestCustomerEntities
    {
        internal static CustomerEntity CustomerEntity => new()
        {
            Id = 1,
            FirstName = "FirstName",
            LastName = "LastName",
            Email = "Email",
            PhoneNumber = "+1234567",
        };

        internal static List<CustomerEntity> CustomerEntityCollection => new ()
        {
            CustomerEntity,
        };
    }
}
