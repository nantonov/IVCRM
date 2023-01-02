using IVCRM.API.ViewModels;

namespace IVCRM.BLL.UnitTests.TestData.ViewModels
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

        internal static CustomerDetailsViewModel CustomerDetailsViewModel => new()
        {
            Id = 1,
            FirstName = "FirstName",
            LastName = "LastName",
            Email = "Email",
            PhoneNumber = "+1234567",
            DateOfBirth = DateTime.MaxValue,
            Address = TestAddressViewModels.ValidAddressViewModel,
            Orders = TestOrderViewModels.OrderViewModelCollection,
        };

        internal static ChangeCustomerViewModel ValidChangeCustomerViewModel => new()
        {
            FirstName = "FirstName",
            LastName = "LastName",
            Email = "Email",
            PhoneNumber = "+1234567",
        };
    }
}
