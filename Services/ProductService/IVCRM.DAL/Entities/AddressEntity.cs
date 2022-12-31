namespace IVCRM.DAL.Entities
{
    public class AddressEntity
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public List<CustomerEntity> Customers { get; set; }
    }
}
