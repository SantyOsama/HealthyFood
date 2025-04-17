using Microsoft.AspNetCore.Mvc;
using HealthyFood.Repositories;

namespace HealthyFood.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepo productRepo;

        public ProductController(IProductRepo productRepo)
        {
            this.productRepo = productRepo;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string category = "ALL", int pageNumber = 1, int pageSize = 8)
        {
            var (products, totalPages) = await productRepo.GetPagedProductsAsync(pageNumber, pageSize, category);

            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = pageNumber;
            ViewBag.Category = category;

            return View(products);
        }
    }
}
