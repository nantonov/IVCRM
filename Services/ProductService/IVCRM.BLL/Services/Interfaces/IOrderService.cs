using IVCRM.BLL.Models;

namespace IVCRM.BLL.Services.Interfaces
{
    public interface IOrderService : IBaseService<Order>
    {
        new Task<OrderDetails> GetById(int id);
    }
}
