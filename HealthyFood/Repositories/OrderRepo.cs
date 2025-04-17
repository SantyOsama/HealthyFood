
namespace HealthyFood.Repositories
{
    public class OrderRepo : IOrderRepo
    {
        private readonly AppDbContext context;

        public OrderRepo(AppDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Order entity)
        {
            await context.Orders.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var order = await context.Orders.FindAsync(id);
            if (order != null)
            {
                context.Orders.Remove(order);
            }
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await context.Orders.ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await context.Orders.FindAsync(id);
        }

        public async Task UpdateAsync(Order entity)
        {
            context.Orders.Update(entity);
        }

        private async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
