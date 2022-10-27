using IVCRM.DAL.Infrastructure;
using IVCRM.DAL.Entities;
using IVCRM.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<CustomerEntity>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<CustomerEntity?> GetById(int id)
        {
            return await _context.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<CustomerEntity?> Update(CustomerEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<CustomerEntity?> Delete(int id)
        {
            var entity = await GetById(id);

            _context.Customers.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
