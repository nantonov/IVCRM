using IVCRM.BLL.Models;

namespace IVCRM.BLL.Services.Interfaces
{
    public interface IProductCategoryService : IBaseService<ProductCategory>
    {
        IEnumerable<ProductCategory> GetCategoriesTree();
    }
}
