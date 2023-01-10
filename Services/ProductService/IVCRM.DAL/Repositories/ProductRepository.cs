using IVCRM.DAL.Infrastructure;
using IVCRM.DAL.Entities;
using IVCRM.DAL.Repositories.Interfaces;

namespace IVCRM.DAL.Repositories
{
    public class ProductRepository : BaseRepository<ProductEntity>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) { }

        public async Task UpdatePictureUri(int id, string uri)
        {
            var product = new ProductEntity() { Id = id, PictureUri = uri };
            _dbSet.Attach(product).Property(x => x.PictureUri).IsModified = true;

            await _context.SaveChangesAsync();
        }
    }
}
