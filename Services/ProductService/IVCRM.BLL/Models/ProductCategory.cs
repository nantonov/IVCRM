using IVCRM.BLL.Models.Interfaces;

namespace IVCRM.BLL.Models
{
    public class ProductCategory : IModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? ParentCategoryId { get; set; }
        public virtual ICollection<ProductCategory>? ChildCategories { get; set; }
    }
}
