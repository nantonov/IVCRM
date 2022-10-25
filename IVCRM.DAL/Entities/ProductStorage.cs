namespace IVCRM.DAL.Entities
{
    public class ProductStorage
    {
        public int ProductId { get; set; }
        public int StorageId { get; set; }

        public Product? Product { get; set; }
        public Storage? Storage { get; set; }

        public float Quantity { get; set; }
    }
}
