using HealthyFood.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthyFood.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly AppDbContext context;

        public ProductRepo(AppDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Product entity)
        {
            await context.Products.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var product = await context.Products.FindAsync(id);
            if (product != null)
            {
                context.Products.Remove(product);
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await context.Products.Include(p => p.Category).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await context.Products.FindAsync(id);
        }

        public async Task UpdateAsync(Product entity)
        {
            context.Products.Update(entity);
        }

        private async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
        public async Task<(IEnumerable<Product> Products, int TotalPages)> GetPagedProductsAsync(int pageNumber, int pageSize, string category)
        {
            var query = context.Products.AsQueryable();

            if (category != "ALL")
            {
                query = query.Where(p => p.Category.Name == category);
            }

            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var products = await query
                .Include(p => p.Category)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (products, totalPages);
        }
    }
}
