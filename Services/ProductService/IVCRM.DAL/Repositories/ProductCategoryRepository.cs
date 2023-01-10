using IVCRM.DAL.Infrastructure;
using IVCRM.DAL.Entities;
using IVCRM.DAL.Repositories.Interfaces;

namespace IVCRM.DAL.Repositories
{
    public class ProductCategoryRepository : BaseRepository<ProductCategoryEntity>, IProductCategoryRepository
    {
        public ProductCategoryRepository(AppDbContext context) : base(context) { }

        public IEnumerable<ProductCategoryEntity> GetCategoriesTree()
        {
            return _dbSet.AsEnumerable().Where(x => x.ParentCategoryId == null).ToList();
        }
    }
}
