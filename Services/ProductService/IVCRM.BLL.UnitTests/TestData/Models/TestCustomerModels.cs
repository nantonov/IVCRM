using IVCRM.BLL.Models;
using IVCRM.Core;

namespace IVCRM.BLL.UnitTests.TestData.Models
{
    internal static class TestCustomerModels
    {
        internal static Customer CustomerModel => new()
        {
            Id = 1,
            FirstName = "FirstName",
            LastName = "LastName",
            Email = "Email",
            PhoneNumber = "+1234567",
        };

        internal static CustomerDetails CustomerDetailsModel => new()
        {
            Id = 1,
            FirstName = "FirstName",
            LastName = "LastName",
            Email = "Email",
            PhoneNumber = "+1234567",
            DateOfBirth = DateTime.MaxValue,
            Address = TestAddressModels.AddressModel,
            Orders = TestOrderModels.OrderModelCollection,
        };

        internal static List<Customer> CustomerModelCollection => new()
        {
            CustomerModel,
        };

        internal static PagedList<Customer> PaginatedModelCollection => new()
        {
            PageSize = 10,
            CurrentPage = 0,
            TotalCount = 1,
            TotalPages = 1,
            Data = CustomerModelCollection,
        };
    }
}
