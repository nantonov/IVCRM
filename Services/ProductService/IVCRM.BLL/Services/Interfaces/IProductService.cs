using IVCRM.BLL.Models;

namespace IVCRM.BLL.Services.Interfaces
{
    public interface IProductService
    {
        Task<Product> Create(Product model);
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<Product> Update(Product model);
        Task UpdatePictureUri(int id, string uri);
        Task Delete(int id);
        Task<bool> IsEntityExists(int id);
    }
}
