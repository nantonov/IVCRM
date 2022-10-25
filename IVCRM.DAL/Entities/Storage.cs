namespace IVCRM.DAL.Entities
{
    public class Storage
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<ProductStorage>? ProductStorages { get; set; }
    }
}
