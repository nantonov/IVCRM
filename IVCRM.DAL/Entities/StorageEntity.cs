namespace IVCRM.DAL.Entities
{
    public class StorageEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<ProductStorageEntity>? ProductStorages { get; set; }
    }
}
