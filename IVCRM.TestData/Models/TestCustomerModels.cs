using IVCRM.BLL.Models;
using IVCRM.Core;

namespace IVCRM.TestData.Models
{
    public static class TestCustomerModels
    {
        public static Customer CustomerModel => new()
        {
            FirstName = "FirstName",
            LastName = "LastName",
            Email = "Email",
            PhoneNumber = "+1234567",
        };

        public static List<Customer> CustomerModelCollection => new()
        {
            CustomerModel,
        };

        public static PagedList<Customer> PaginatedModelCollection => new()
        {
            PageSize = 10,
            CurrentPage = 0,
            TotalCount = 1,
            TotalPages = 1,
            Data = CustomerModelCollection,
        };
    }
}
