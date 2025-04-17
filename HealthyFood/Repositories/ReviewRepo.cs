
namespace HealthyFood.Repositories
{
    public class ReviewRepo : IReviewRepo
    {
        private readonly AppDbContext context;

        public ReviewRepo(AppDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Review entity)
        {
            await context.Reviews.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var review = await context.Reviews.FindAsync(id);
            if (review != null)
            {
                context.Reviews.Remove(review);
            }
        }

        public async Task<IEnumerable<Review>> GetAllAsync()
        {
            return await context.Reviews.ToListAsync();
        }

        public async Task<Review> GetByIdAsync(int id)
        {
            return await context.Reviews.FindAsync(id);
        }

        public async Task UpdateAsync(Review entity)
        {
            context.Reviews.Update(entity);
        }

        private async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
