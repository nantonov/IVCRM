using IVCRM.Core;
using IVCRM.Core.Models;
using IVCRM.DAL.Entities;

namespace IVCRM.DAL.Repositories.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<CustomerEntity>
    {
        Task<PagedList<CustomerEntity>> GetAll(TableParameters parameters);
    }
}
