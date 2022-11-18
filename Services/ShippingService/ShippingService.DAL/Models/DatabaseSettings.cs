namespace ShippingService.DAL.Models
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string ShipmentCollectionName { get; set; } = null!;
    }
}
