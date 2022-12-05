using IVCRM.BLL.Models;
using IVCRM.DAL.Entities;

namespace IVCRM.BLL.Services.Interfaces
{
    public interface IProductCategoryService
    {
        Task<ProductCategory> Create(ProductCategory model);
        Task<IEnumerable<ProductCategory>> GetAll();
        IEnumerable<ProductCategory> GetCategoriesTree();
        Task<ProductCategory> GetById(int id);
        Task<ProductCategory> Update(ProductCategory model);
        Task Delete(int id);
        Task<bool> IsEntityExists(int id);
    }
}
