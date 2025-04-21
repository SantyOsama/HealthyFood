namespace HealthyFood.Interfaces
{
    public interface IProductRepo : IGenericRepository<Product>
    {
        Task<(IEnumerable<Product> products, int totalPages)> GetPagedProductsAsync(int pageNumber, int pageSize, string category, string query);
        Task<IEnumerable<Product>> SearchAsync(string query);
         Task SaveAsync();
    }
}
