using IVCRM.BLL.Models;

namespace IVCRM.BLL.Services.Interfaces
{
    public interface IAddressService
    {
        Task<Address> Create(Address model);
        Task<IEnumerable<Address>> GetAll();
        Task<Address> GetById(int id);
        Task<Address> Update(Address model);
        Task Delete(int id);
        Task<bool> IsEntityExists(int id);
    }
}
