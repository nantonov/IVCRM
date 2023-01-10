using IVCRM.BLL.Models;
using IVCRM.Core;
using IVCRM.Core.Models;

namespace IVCRM.BLL.Services.Interfaces
{
    public interface ICustomerService : IBaseService<Customer>
    {
        Task<PagedList<Customer>> GetAll(TableParameters parameters);
        new Task<CustomerDetails> GetById(int id);
    }
}
