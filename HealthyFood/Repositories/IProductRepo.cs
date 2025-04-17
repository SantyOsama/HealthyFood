using HealthyFood.Models;

namespace HealthyFood.Repositories
{
    public interface IProductRepo : IGenericRepository<Product>
    {
        Task<(IEnumerable<Product> Products, int TotalPages)> GetPagedProductsAsync(int pageNumber, int pageSize, string category);
    }
}
