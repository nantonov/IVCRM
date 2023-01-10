using IVCRM.DAL.Infrastructure;
using IVCRM.DAL.Entities;
using IVCRM.DAL.Repositories.Interfaces;

namespace IVCRM.DAL.Repositories
{
    public class AddressRepository : BaseRepository<AddressEntity>, IAddressRepository
    {
        public AddressRepository(AppDbContext context) : base(context) { }
    }
}
