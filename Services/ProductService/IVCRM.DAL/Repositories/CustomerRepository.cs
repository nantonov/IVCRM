using IVCRM.Core.Models;
using IVCRM.DAL.Infrastructure;
using IVCRM.DAL.Entities;
using IVCRM.DAL.Extensions;
using IVCRM.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using IVCRM.Core;

namespace IVCRM.DAL.Repositories
{
    public class CustomerRepository : BaseRepository<CustomerEntity>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context) { }

        public Task<PagedList<CustomerEntity>> GetAll(TableParameters parameters)
        {
            return _dbSet.ToPagedList(parameters);
        }

        public override Task<CustomerEntity?> GetById(int id)
        {
            return _dbSet.AsNoTracking()
                .Include(x => x.Address)
                .Include(x => x.Orders)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
