using IVCRM.DAL.Infrastructure;
using IVCRM.DAL.Entities;
using IVCRM.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IVCRM.DAL.Repositories
{
    public class OrderRepository : BaseRepository<OrderEntity>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context) { }

        public override async Task<OrderEntity?> GetById(int id)
        {
            return await _context.Orders.AsNoTracking()
                .Include(x => x.Customer)
                .Include(x => x.ProductOrders)!
                .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
