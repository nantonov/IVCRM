using IVCRM.BLL.Models;
using IVCRM.Core;
using IVCRM.Core.Models;

namespace IVCRM.BLL.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> Create(Customer model);
        Task<PagedList<Customer>> GetAll(TableParameters parameters);
        Task<CustomerDetails> GetById(int id);
        Task<Customer> Update(Customer model);
        Task Delete(int id);
        Task<bool> IsEntityExists(int id);
    }
}
