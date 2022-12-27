using IVCRM.Core;
using IVCRM.Core.Models;
using IVCRM.DAL.Entities;

namespace IVCRM.DAL.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<CustomerEntity> Create(CustomerEntity entity);
        Task<PagedList<CustomerEntity>> GetAll(TableParameters parameters);
        Task<CustomerEntity?> GetById(int id);
        Task<CustomerEntity?> Update(CustomerEntity entity);
        Task Delete(int id);
    }
}
