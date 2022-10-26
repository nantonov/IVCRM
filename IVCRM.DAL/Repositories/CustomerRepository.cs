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

        public async Task<CustomerEntity> Create(CustomerEntity request)
        {
            await _context.Customers.AddAsync(request);
            await _context.SaveChangesAsync();
            
            return request;
        }

        public async Task<IEnumerable<CustomerEntity>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<CustomerEntity?> GetById(int id)
        {
            return await _context.Customers.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<CustomerEntity?> Update(CustomerEntity request)
        {
            var entity = await GetById(request.Id);
            if (entity is null)
            {
                return null;
            }

            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.PhoneNumber = request.PhoneNumber;

            _context.Customers.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<CustomerEntity?> Delete(int id)
        {
            var entity = await GetById(id);
            if (entity is null)
            {
                return null;
            }

            _context.Customers.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
