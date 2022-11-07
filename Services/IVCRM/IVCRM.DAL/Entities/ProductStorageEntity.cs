namespace IVCRM.DAL.Entities
{
    public class ProductStorageEntity
    {
        public int ProductId { get; set; }
        public int StorageId { get; set; }

        public ProductEntity? Product { get; set; }
        public StorageEntity? Storage { get; set; }

        public float Quantity { get; set; }
    }
}
