using IVCRM.BLL.Models;

namespace IVCRM.BLL.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Order> Create(Order model);
        Task<IEnumerable<Order>> GetAll();
        Task<OrderDetails> GetById(int id);
        Task<Order> Update(Order model);
        Task Delete(int id);
        Task<bool> IsEntityExists(int id);
    }
}
