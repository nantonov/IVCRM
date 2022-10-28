using IVCRM.BLL.Models;
using IVCRM.DAL.Entities;

namespace IVCRM.UnitTests.TestData.Models
{
    internal static class TestCustomers
    {
        internal static Customer Customer => new()
        {
            Id = 1,
            FirstName = "FirstName",
            LastName = "LastName",
            PhoneNumber = "Number",
        };

        internal static List<Customer> CustomerCollection => new()
        {
            Customer,
        };
    }
}
