using IVCRM.DAL.Entities;

namespace IVCRM.DAL.integrationTests.TestData.Entities
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

        internal static List<AddressEntity> AddressEntityCollection => new ()
        {
            AddressEntity,
        };
    }
}
