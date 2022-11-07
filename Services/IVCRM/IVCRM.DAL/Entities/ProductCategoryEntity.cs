using IVCRM.DAL.Entities.Interfaces;

namespace IVCRM.DAL.Entities
{
    public class ProductCategoryEntity : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<ProductEntity>? Products { get; set; }
    }
}
