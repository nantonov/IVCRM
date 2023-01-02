using IVCRM.DAL.Entities;

namespace IVCRM.API.IntegrationTests.TestData.Entities
{
    internal static class TestAddressEntities
    {
        internal static AddressEntity AddressEntity => new()
        {
            Id = 1,
            Street = "123 Main Street",
            City = "New York",
            State = "NY",
            ZipCode = "10001"
        };
    }
}
