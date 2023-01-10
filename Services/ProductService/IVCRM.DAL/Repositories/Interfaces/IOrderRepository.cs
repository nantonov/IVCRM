using IVCRM.DAL.Entities;

namespace IVCRM.DAL.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<OrderEntity> Create(OrderEntity entity);
        Task<List<OrderEntity>> GetAll();
        Task<OrderEntity?> GetById(int id);
        Task<OrderEntity?> Update(OrderEntity entity);
        Task Delete(int id);
    }
}
