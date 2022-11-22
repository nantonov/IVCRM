using IVCRM.BLL.Models;

namespace IVCRM.BLL.Services.Interfaces
{
    public interface IProductCategoryService
    {
        Task<ProductCategory> Create(ProductCategory model);
        IEnumerable<ProductCategory> GetAll();
        Task<ProductCategory> GetById(int id);
        Task<ProductCategory> Update(ProductCategory model);
        Task Delete(int id);
        Task<bool> IsEntityExists(int id);
    }
}
