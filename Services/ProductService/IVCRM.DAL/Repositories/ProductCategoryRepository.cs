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

        public async Task<IEnumerable<ProductCategoryEntity>> GetAll()
        {
            return await _context.ProductCategories.ToListAsync();
        }

        public IEnumerable<ProductCategoryEntity> GetCategoriesTree()
        {
            return _context.ProductCategories.AsEnumerable().Where(x => x.ParentCategoryId == null).ToList();
        }

        public async Task<ProductCategoryEntity?> GetById(int id)
        {
            return await _context.ProductCategories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
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
