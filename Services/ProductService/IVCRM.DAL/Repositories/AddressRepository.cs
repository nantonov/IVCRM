using IVCRM.DAL.Infrastructure;
using IVCRM.DAL.Entities;
using IVCRM.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IVCRM.DAL.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _context;

        public AddressRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AddressEntity> Create(AddressEntity entity)
        {
            await _context.Addresses.AddAsync(entity);
            await _context.SaveChangesAsync();
            
            return entity;
        }

        public Task<List<AddressEntity>> GetAll()
        {
            return _context.Addresses.ToListAsync();
        }

        public Task<AddressEntity?> GetById(int id)
        {
            return _context.Addresses.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<AddressEntity?> Update(AddressEntity entity)
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
                _context.Addresses.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
