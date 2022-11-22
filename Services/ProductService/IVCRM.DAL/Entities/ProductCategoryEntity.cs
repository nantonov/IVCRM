using IVCRM.DAL.Entities.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace IVCRM.DAL.Entities
{
    public class ProductCategoryEntity : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? ParentCategoryId { get; set; }
        public virtual ProductCategoryEntity? ParentCategory { get; set; }
        public virtual ICollection<ProductCategoryEntity>? ChildCategories { get; set; }
        public ICollection<ProductEntity>? Products { get; set; }
    }
}
