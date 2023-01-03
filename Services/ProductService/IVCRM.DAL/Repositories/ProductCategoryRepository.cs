using IVCRM.DAL.Infrastructure;
using IVCRM.DAL.Entities;
using IVCRM.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace IVCRM.DAL.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly AppDbContext _context;

        public ProductCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductCategoryEntity> Create(ProductCategoryEntity entity)
        {
            await _context.ProductCategories.AddAsync(entity);
            await _context.SaveChangesAsync();
            
            return entity;
        }

        public Task<List<ProductCategoryEntity>> GetAll()
        {
            return _context.ProductCategories.ToListAsync();
        }

        public IEnumerable<ProductCategoryEntity> GetCategoriesTree()
        {
            return _context.ProductCategories.AsEnumerable().Where(x => x.ParentCategoryId == null).ToList();
        }

        public Task<ProductCategoryEntity?> GetById(int id)
        {
            return _context.ProductCategories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ProductCategoryEntity?> Update(ProductCategoryEntity entity)
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
                _context.ProductCategories.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
