using IVCRM.Core.Models;
using IVCRM.DAL.Infrastructure;
using IVCRM.DAL.Entities;
using IVCRM.DAL.Extensions;
using IVCRM.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using IVCRM.Core;

namespace IVCRM.DAL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CustomerEntity> Create(CustomerEntity entity)
        {
            await _context.Customers.AddAsync(entity);
            await _context.SaveChangesAsync();
            
            return entity;
        }

        public Task<PagedList<CustomerEntity>> GetAll(TableParameters parameters)
        {
            return _context.Customers.ToPagedList(parameters);
        }

        public Task<CustomerEntity?> GetById(int id)
        {
            return _context.Customers.AsNoTracking()
                .Include(x => x.Address)
                .Include(x => x.Orders)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<CustomerEntity?> Update(CustomerEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity is not null)
            {
                _context.Customers.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
