namespace IVCRM.API.ViewModels
{
    public class ProductCategoryViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? ParentCategoryId { get; set; }
        public ICollection<ProductCategoryViewModel>? ChildCategories { get; set; }
    }
}
