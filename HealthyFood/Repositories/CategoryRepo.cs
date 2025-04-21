
using System.Collections;
using HealthyFood.Interfaces;

namespace HealthyFood.Repositories
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly AppDbContext context;

        public CategoryRepo(AppDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Category entity)
        {
            await context.Categories.AddAsync(entity);                    
        }

        public async Task DeleteAsync(int id)
        {
            var category = await context.Categories.FindAsync(id);
            if (category != null)
            {
                context.Categories.Remove(category);                         
            }
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await context.Categories.FindAsync(id);  
        }

        public async Task UpdateAsync(Category entity)
        {
            context.Categories.Update(entity);                   
        }

        private async Task SaveAsync()
        {
            await context.SaveChangesAsync();   
        }
    }
}
