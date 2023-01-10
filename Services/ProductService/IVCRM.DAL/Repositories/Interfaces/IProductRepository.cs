using IVCRM.DAL.Entities;

namespace IVCRM.DAL.Repositories.Interfaces
{
    public interface IProductRepository : IBaseRepository<ProductEntity>
    {
        Task UpdatePictureUri(int id, string uri);
    }
}
