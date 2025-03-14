﻿using CustomerOrderManagement.Domain.Entities;
using CustomerOrderManagement.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace CustomerOrderManagement.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
        }

        public async Task DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
