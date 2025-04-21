using System.Threading.Tasks;
using HealthyFood.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HealthyFood.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductRepo productRepo;
        private readonly ICategoryRepo categoryRepo;

        public AdminController(IProductRepo productRepo, ICategoryRepo categoryRepo)
        {
            this.productRepo = productRepo;
            this.categoryRepo = categoryRepo;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await categoryRepo.GetAllAsync();
            ViewBag.Catrgories=categories;
            return View("Add");
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> SaveAdd(ProductAddVM productFromReq)
        {
            if(ModelState.IsValid && productFromReq.CategoryId!=0)
            {
                Product product = new Product
                {
                    Name = productFromReq.Name,
                    Price = productFromReq.Price,
                    ImageUrl = productFromReq.ImageUrl,
                    Stock = productFromReq.Stock,
                    CategoryId = productFromReq.CategoryId
                };
                await productRepo.AddAsync(product);
                await productRepo.SaveAsync();

                return RedirectToAction("Index", "Product");
            }

            if (productFromReq.CategoryId == 0)
            {
                ModelState.AddModelError("CategoryId", "Please select category.");
            }

            var categories = await categoryRepo.GetAllAsync();
            ViewBag.Catrgories=categories;
            return View ("Add", productFromReq);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int productId)
        {
            Product productFromDb=await productRepo.GetByIdAsync(productId);
            ProductEditVM product = new ProductEditVM
            {
                Id = productId,
                Name = productFromDb.Name,
                Price = productFromDb.Price,
                Stock = productFromDb.Stock,
                CategoryId = productFromDb.CategoryId,
                ImageUrl = productFromDb.ImageUrl
            };
            var categories = await categoryRepo.GetAllAsync();
            ViewBag.Catrgories = categories;
            return View("Edit", product);
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> SaveEdit(ProductEditVM productFromReq)
        {
            if (ModelState.IsValid && productFromReq.CategoryId != 0)
            {
                Product product = await productRepo.GetByIdAsync(productFromReq.Id);

                product.Name = productFromReq.Name;
                product.Price = productFromReq.Price;
                product.ImageUrl = productFromReq.ImageUrl;
                product.Stock = productFromReq.Stock;
                product.CategoryId = productFromReq.CategoryId;

                await productRepo.UpdateAsync(product);
                await productRepo.SaveAsync();

                return RedirectToAction("Index", "Product");
            }

            if (productFromReq.CategoryId == 0)
            {
                ModelState.AddModelError("CategoryId", "Please select category");
            }

            var categories = await categoryRepo.GetAllAsync();
            ViewBag.Catrgories = categories;
            return View("Edit", productFromReq);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await productRepo.DeleteAsync(id);
                await productRepo.SaveAsync();
                return RedirectToAction("Index", "Product");
            }
            catch (Exception e)
            {
                return NotFound("Sorry You Cant Delete This Product");
            }
        }
    }
}
