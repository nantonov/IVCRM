using IVCRM.DAL.Entities;

namespace IVCRM.DAL.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<CustomerEntity> Create(CustomerEntity request);
        Task<IEnumerable<CustomerEntity>> GetAll();
        Task<CustomerEntity?> GetById(int id);
        Task<CustomerEntity?> Update(CustomerEntity request);
        Task<CustomerEntity?> Delete(int id);
    }
}
