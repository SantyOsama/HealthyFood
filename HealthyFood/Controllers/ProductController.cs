
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
        public async Task<IActionResult> Index(string category = "ALL", int pageNumber = 1, int pageSize = 8, string query = "")
        {
            var (products, totalPages) = await productRepo.GetPagedProductsAsync(pageNumber, pageSize, category, query);

            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = pageNumber;
            ViewBag.Category = category;
            ViewBag.SearchQuery = query;

            return View(products);
        }


        [HttpGet]
        public async Task<IActionResult> Search(string query, string category = "ALL", int pageNumber = 1, int pageSize = 8)
        {
            if (string.IsNullOrWhiteSpace(query))
                return RedirectToAction("Index", new { category, pageNumber, pageSize });

            var (products, totalPages) = await productRepo.GetPagedProductsAsync(pageNumber, pageSize, category, query);

            ViewBag.SearchQuery = query;
            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = pageNumber;
            ViewBag.Category = category;

            return View("Index", products); 
        }


    }
}
