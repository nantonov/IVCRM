using IVCRM.DAL.Entities;

namespace IVCRM.DAL.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<ProductEntity> Create(ProductEntity entity);
        Task<IEnumerable<ProductEntity>> GetAll();
        Task<ProductEntity?> GetById(int id);
        Task<ProductEntity?> Update(ProductEntity entity);
        Task Delete(int id);
    }
}
