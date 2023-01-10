using IVCRM.BLL.Models;

namespace IVCRM.BLL.Services.Interfaces
{
    public interface IProductService : IBaseService<Product>
    {
        Task UpdatePictureUri(int id, string uri);
    }
}
