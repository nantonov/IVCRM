using IVCRM.BLL.Models;
using IVCRM.DAL.Entities;

namespace IVCRM.BLL.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> Create(Customer request);
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer> GetById(int id);
        Task<Customer> Update(Customer request);
        Task<Customer> Delete(int id);
    }
}
