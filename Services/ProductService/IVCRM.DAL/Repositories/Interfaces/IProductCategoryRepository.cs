using IVCRM.DAL.Entities;

namespace IVCRM.DAL.Repositories.Interfaces
{
    public interface IProductCategoryRepository : IBaseRepository<ProductCategoryEntity>
    {
        IEnumerable<ProductCategoryEntity> GetCategoriesTree();
    }
}
