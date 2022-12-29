using IVCRM.API.ViewModels;
using IVCRM.Core;
using IVCRM.DAL.Entities;

namespace IVCRM.API.IntegrationTests.TestData.ViewModels
{
    internal static class TestCustomerViewModels
    {
        internal static CustomerViewModel ValidCustomerViewModel => new()
        {
            Id = 1,
            FullName = "FirstName LastName",
            Email = "Email",
            PhoneNumber = "+1234567",
        };

        internal static CustomerViewModel UpdatedCustomerViewModel => new()
        {
            Id = 1,
            FullName = "UpdatedFirstName UpdatedLastName",
            Email = "Email",
            PhoneNumber = "+1234567",
        };

        internal static List<CustomerViewModel> ValidCustomerViewModelCollection => new()
        {
            new ()
            {
                FullName = "FirstName1 LastName1",
                Email = "Email",
                PhoneNumber = "+1234567",
            },
            new ()
            {
                FullName = "FirstName2 LastName2",
                Email = "Email",
                PhoneNumber = "+2234567",
            },
            new ()
            {
                FullName = "FirstName3 LastName3",
                Email = "Email",
                PhoneNumber = "+3234567",
            },
        };

        internal static ChangeCustomerViewModel ValidChangeCustomerViewModel => new()
        {
            FirstName = "FirstName",
            LastName = "LastName",
            Email = "Email",
            PhoneNumber = "+1234567",
        };

        internal static ChangeCustomerViewModel UpdatedChangeCustomerViewModel => new()
        {
            FirstName = "UpdatedFirstName",
            LastName = "UpdatedLastName",
            Email = "Email",
            PhoneNumber = "+1234567",
        };

        internal static PagedList<CustomerViewModel> PaginatedCustomerViewModel => new()
        {
            PageSize = 10,
            CurrentPage = 0,
            TotalCount = 1,
            TotalPages = 1,
            Data = ValidCustomerViewModelCollection,
        };
    }
}
