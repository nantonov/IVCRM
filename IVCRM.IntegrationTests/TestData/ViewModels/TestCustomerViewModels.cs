using IVCRM.API.ViewModels;

namespace IVCRM.IntegrationTests.TestData.Models
{
    internal static class TestCustomerViewModels
    {
        internal static CustomerViewModel CustomerViewModel => new()
        {
            Id = 1,
            FullName = "FirstName LastName",
            PhoneNumber = "Number",
        };

        internal static ChangeCustomerViewModel ChangeCustomerViewModel => new()
        {
            FirstName = "FirstName",
            LastName = "LastName",
            PhoneNumber = "Number",
        };
    }
}
