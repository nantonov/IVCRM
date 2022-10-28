using IVCRM.API.ViewModels;

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

        internal static ChangeCustomerViewModel ChangeCustomerViewModel => new()
        {
            FirstName = "FirstName",
            LastName = "LastName",
            PhoneNumber = "+1234567",
        };
    }
}
