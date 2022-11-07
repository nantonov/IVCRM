using StockManagement.DAL.Entities;

namespace StockManagement.DAL.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<ProductEntity> Create(ProductEntity entity);
        Task<IEnumerable<ProductEntity>> GetAll();
        Task<IEnumerable<ProductEntity>> GetByName(string name);
        Task<ProductEntity?> GetById(int id);
        Task<ProductEntity?> Update(ProductEntity entity);
        Task Delete(int id);
    }
}
