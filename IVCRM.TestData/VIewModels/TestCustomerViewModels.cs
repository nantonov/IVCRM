using IVCRM.API.ViewModels;
using IVCRM.Core;

namespace IVCRM.TestData.ViewModels
{
    public static class TestCustomerViewModels
    {
        public static CustomerViewModel ValidCustomerViewModel => new()
        {
            FullName = "FirstName LastName",
            Email = "Email",
            PhoneNumber = "+1234567",
        };

        public static List<CustomerViewModel> ValidCustomerViewModelCollection => new()
        {
            ValidCustomerViewModel,
        };

        public static CustomerViewModel UpdatedCustomerViewModel => new()
        {
            Id = 1,
            FullName = "UpdatedFirstName UpdatedLastName",
            Email = "Email",
            PhoneNumber = "+1234567",
        };

        public static ChangeCustomerViewModel ValidChangeCustomerViewModel => new()
        {
            FirstName = "FirstName",
            LastName = "LastName",
            Email = "Email",
            PhoneNumber = "+1234567",
        };

        public static ChangeCustomerViewModel UpdatedChangeCustomerViewModel => new()
        {
            FirstName = "UpdatedFirstName",
            LastName = "UpdatedLastName",
            Email = "Email",
            PhoneNumber = "+1234567",
        };

        public static PagedList<CustomerViewModel> PaginatedCustomerViewModel => new()
        {
            PageSize = 10,
            CurrentPage = 0,
            TotalCount = 1,
            TotalPages = 1,
            Data = ValidCustomerViewModelCollection,
        };
    }
}
