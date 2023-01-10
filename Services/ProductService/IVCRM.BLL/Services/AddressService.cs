using AutoMapper;
using IVCRM.BLL.Models;
using IVCRM.BLL.Services.Interfaces;
using IVCRM.DAL.Entities;
using IVCRM.DAL.Repositories.Interfaces;

namespace IVCRM.BLL.Services
{
    public class AddressService : BaseService<Address, AddressEntity>, IAddressService
    {
        public AddressService(IAddressRepository repository, IMapper mapper) : base(repository, mapper) { }
    }
}
