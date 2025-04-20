
using Microsoft.EntityFrameworkCore;

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
        public async Task<(IEnumerable<Product> products, int totalPages)> GetPagedProductsAsync(int pageNumber, int pageSize, string category, string query)
        {
            var queryable = context.Products.AsQueryable();

            if (category != "ALL")
            {
                queryable = queryable.Where(p => p.Category.Name == category);
            }

            if (!string.IsNullOrWhiteSpace(query))
            {
                queryable = queryable.Where(p => p.Name.Contains(query));
            }

            var totalItems = await queryable.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var products = await queryable
                .Include(p => p.Category)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (products, totalPages);
        }



        public async Task<IEnumerable<Product>> SearchAsync(string query)
        {
            return await context.Products
                .Where(p => p.Name.Contains(query))  
                .ToListAsync();
        }

    }
}
