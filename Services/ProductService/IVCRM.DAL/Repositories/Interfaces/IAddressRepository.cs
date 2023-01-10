using IVCRM.DAL.Entities;

namespace IVCRM.DAL.Repositories.Interfaces
{
    public interface IAddressRepository
    {
        Task<AddressEntity> Create(AddressEntity entity);
        Task<List<AddressEntity>> GetAll();
        Task<AddressEntity?> GetById(int id);
        Task<AddressEntity?> Update(AddressEntity entity);
        Task Delete(int id);
    }
}
