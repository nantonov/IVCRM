using IVCRM.DAL.Entities.Interfaces;

namespace IVCRM.DAL.Entities
{
    public class StorageEntity : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<ProductStorageEntity>? ProductStorages { get; set; }
    }
}
