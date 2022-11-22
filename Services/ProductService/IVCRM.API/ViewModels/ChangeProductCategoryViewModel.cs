namespace IVCRM.API.ViewModels
{
    public class ChangeProductCategoryViewModel
    {
        public string Name { get; set; } = null!;
        public int? ParentCategoryId { get; set; }
    }
}
