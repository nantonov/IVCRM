using IVCRM.API.ViewModels;
using IVCRM.DAL.Entities;

namespace IVCRM.API.IntegrationTests.TestData.ViewModels
{
    internal static class TestCustomerViewModels
    {
        internal static CustomerViewModel CustomerViewModel => new()
        {
            Id = 1,
            FullName = "FirstName LastName",
            PhoneNumber = "+1234567",
        };

        internal static CustomerViewModel UpdatedCustomerViewModel => new()
        {
            Id = 1,
            FullName = "UpdatedFirstName UpdatedLastName",
            PhoneNumber = "+1234567",
        };

        internal static List<CustomerViewModel> CustomerViewModelCollection => new()
        {
            new ()
            {
                FullName = "FirstName1 LastName1",
                PhoneNumber = "+1234567",
            },
            new ()
            {
                FullName = "FirstName2 LastName2",
                PhoneNumber = "+2234567",
            },
            new ()
            {
                FullName = "FirstName3 LastName3",
                PhoneNumber = "+3234567",
            },
        };

        internal static ChangeCustomerViewModel ChangeCustomerViewModel => new()
        {
            FirstName = "FirstName",
            LastName = "LastName",
            PhoneNumber = "+1234567",
        };

        internal static ChangeCustomerViewModel UpdatedChangeCustomerViewModel => new()
        {
            FirstName = "UpdatedFirstName",
            LastName = "UpdatedLastName",
            PhoneNumber = "+1234567",
        };
    }
}
