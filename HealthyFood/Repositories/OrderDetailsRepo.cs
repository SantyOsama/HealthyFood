
namespace HealthyFood.Repositories
{
    public class OrderDetailsRepo : IOrderDetailsRepo
    {
        private readonly AppDbContext context;

        public OrderDetailsRepo(AppDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(OrderDetails entity)
        {
            await context.OrderDetails.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var orderDetails = await context.OrderDetails.FindAsync(id);
            if (orderDetails != null)
            {
                context.OrderDetails.Remove(orderDetails);
            }
        }

        public async Task<IEnumerable<OrderDetails>> GetAllAsync()
        {
            return await context.OrderDetails.ToListAsync();
        }

        public async Task<OrderDetails> GetByIdAsync(int id)
        {
            return await context.OrderDetails.FindAsync(id);
        }

        public async Task UpdateAsync(OrderDetails entity)
        {
            context.OrderDetails.Update(entity);
        }

        private async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
