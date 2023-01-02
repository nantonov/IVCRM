using IVCRM.BLL.Models;

namespace IVCRM.BLL.UnitTests.TestData.Models
{
    internal static class TestAddressModels
    {
        internal static Address AddressModel => new()
        {
            Id = 1,
            Street = "123 Main Street",
            City = "New York",
            State = "NY",
            ZipCode = "10001"
        };

        internal static List<Address> AddressModelCollection => new ()
        {
            AddressModel,
        };
    }
}
