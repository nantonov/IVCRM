﻿using StockManagement.DAL.Infrastructure;
using StockManagement.DAL.Entities;
using StockManagement.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace StockManagement.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductEntity> Create(ProductEntity entity)
        {
            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
            
            return entity;
        }

        public async Task<IEnumerable<ProductEntity>> GetAll()
        {
            return await _context.Products.Include(x => x.Category).ToListAsync();
        }

        public async Task<IEnumerable<ProductEntity>> GetByName(string name)
        {
            return await _context.Products.Where(x => x.Name != null && x.Name.ToUpper()
                                                                                .Equals(name.ToUpper()))
                                                                                .ToListAsync();
        }

        public async Task<ProductEntity?> GetById(int id)
        {
            return await _context.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ProductEntity?> Update(ProductEntity entity)
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
                _context.Products.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
