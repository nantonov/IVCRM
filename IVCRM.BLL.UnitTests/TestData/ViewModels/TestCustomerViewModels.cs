using IVCRM.API.ViewModels;
using IVCRM.DAL.Entities;

namespace IVCRM.BLL.UnitTests.TestData.ViewModels
{
    internal static class TestCustomerViewModels
    {
        internal static CustomerViewModel CustomerViewModel => new()
        {
            Id = 1,
            FullName = "FirstName LastName",
            PhoneNumber = "+1234567",
        };

        internal static List<CustomerViewModel> CustomerViewModelCollection => new()
        {
            new ()
            {
                FullName = "FirstName1 LastName1",
                PhoneNumber = "Number1",
            },
            new ()
            {
                FullName = "FirstName2 LastName2",
                PhoneNumber = "Number2",
            },
            new ()
            {
                FullName = "FirstName3 LastName3",
                PhoneNumber = "Number3",
            },
        };

        internal static ChangeCustomerViewModel ChangeCustomerViewModel => new()
        {
            FirstName = "FirstName",
            LastName = "LastName",
            PhoneNumber = "+1234567",
        };
    }
}
