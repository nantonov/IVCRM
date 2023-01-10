using IVCRM.DAL.Infrastructure;
using IVCRM.DAL.Entities;
using IVCRM.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IVCRM.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<OrderEntity> Create(OrderEntity entity)
        {
            await _context.Orders.AddAsync(entity);
            await _context.SaveChangesAsync();
            
            return entity;
        }

        public Task<List<OrderEntity>> GetAll()
        {
            return _context.Orders.ToListAsync();
        }

        public async Task<OrderEntity?> GetById(int id)
        {
            return await _context.Orders.AsNoTracking()
                .Include(x => x.Customer)
                .Include(x => x.OrderItems)!
                .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<OrderEntity?> Update(OrderEntity entity)
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
                _context.Orders.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
