using IVCRM.DAL.Entities.Interfaces;

namespace IVCRM.DAL.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : IEntity
    {
        Task<TEntity> Create (TEntity entity);
        Task<List<TEntity>> GetAll();
        Task<TEntity?> GetById(int id);
        Task<TEntity?> Update (TEntity entity);
        Task Delete (int id);
    }
}
