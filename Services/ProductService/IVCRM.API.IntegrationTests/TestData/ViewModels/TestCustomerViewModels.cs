using IVCRM.API.ViewModels;

namespace IVCRM.API.IntegrationTests.TestData.ViewModels
{
    internal static class TestCustomerViewModels
    {
        internal static CustomerViewModel ValidCustomerViewModel => new()
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

        internal static List<CustomerViewModel> ValidCustomerViewModelCollection => new()
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

        internal static ChangeCustomerViewModel ValidChangeCustomerViewModel => new()
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
