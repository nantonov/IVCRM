using IVCRM.BLL.Models;
using IVCRM.DAL.Entities;

namespace IVCRM.UnitTests.TestData.Models
{
    internal static class TestCustomerEntities
    {
        internal static CustomerEntity CustomerEntity => new()
        {
            Id = 1,
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
