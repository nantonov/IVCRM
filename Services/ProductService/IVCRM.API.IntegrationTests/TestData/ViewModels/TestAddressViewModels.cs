using IVCRM.API.ViewModels;

namespace IVCRM.API.IntegrationTests.TestData.ViewModels
{
    internal static class TestAddressViewModels
    {
        internal static AddressViewModel ValidAddressViewModel => new()
        {
            Id = 1,
            Street = "123 Main Street",
            City = "New York",
            State = "NY",
            ZipCode = "10001"
        };

        internal static ChangeAddressViewModel ValidChangeAddressViewModel => new()
        {
            Street = "123 Main Street",
            City = "New York",
            State = "NY",
            ZipCode = "10001"
        };
    }
}
