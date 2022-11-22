using IVCRM.DAL.Entities;

namespace IVCRM.DAL.Repositories.Interfaces
{
    public interface IProductCategoryRepository
    {
        Task<ProductCategoryEntity> Create(ProductCategoryEntity entity);
        IEnumerable<ProductCategoryEntity> GetAll();
        Task<ProductCategoryEntity?> GetById(int id);
        Task<ProductCategoryEntity?> Update(ProductCategoryEntity entity);
        Task Delete(int id);
    }
}
