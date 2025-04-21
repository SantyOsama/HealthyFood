
using HealthyFood.Interfaces;

public class CartController : Controller
{
    private readonly IProductRepo productRepo;

    public CartController(IProductRepo productRepo)
    {
        this.productRepo = productRepo;
    }

    private List<CartItem> GetCartItems()
    {
        var cart = HttpContext.Session.GetString("Cart");
        return cart == null ? new List<CartItem>() : JsonConvert.DeserializeObject<List<CartItem>>(cart);
    }

    private void SaveCartSession(List<CartItem> cart)
    {
        HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));
    }

    public IActionResult Index()
    {
        var cart = GetCartItems();
        return View(cart);
    }


    /********************/
    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> AddToCart(int id)
    {
        var product = await productRepo.GetByIdAsync(id);
        if (product == null) return Json(new { success = false, message = "Product not found" });

        var cart = GetCartItems();
        var item = cart.FirstOrDefault(x => x.ProductId == id);

        if (item == null)
        {
            cart.Add(new CartItem
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                Quantity = 1
            });
            SaveCartSession(cart);
            return Json(new { success = true, message = "Product added to cart successfully!" });
        }
        else
        {
            item.Quantity++;
            SaveCartSession(cart);
            return Json(new { success = true, message = "Product quantity updated!" });
        }
    }


    [HttpGet]
    public IActionResult Remove(int id)
    {
        var cart = GetCartItems();
        var item = cart.FirstOrDefault(x => x.ProductId == id);
        if (item != null)
        {
            cart.Remove(item);
            SaveCartSession(cart);
        }
        return RedirectToAction("Index");
    }


    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult UpdateQuantity(int productId, int quantity)
    {
        if (quantity < 1)
        {
            return Json(new { success = false, message = "Quantity cannot be less than 1." });
        }

        var cart = GetCartItems(); 
        var item = cart.FirstOrDefault(x => x.ProductId == productId);
        if (item != null)
        {
            item.Quantity = quantity;
            if (item.Quantity <= 0)
            {
                cart.Remove(item); 
            }

            SaveCartSession(cart); 
        }

        var totalCartPrice = cart.Sum(x => x.Price * x.Quantity);
        var updatedItemPrice = item?.Price * item?.Quantity ?? 0;

        return Json(new
        {
            success = true,
            totalCartPrice = totalCartPrice,
            updatedItemPrice = updatedItemPrice,
            itemId = productId
        });
    }



    public IActionResult Clear()
    {
        SaveCartSession(new List<CartItem>());
        return RedirectToAction("Index");
    }

    public IActionResult Checkout()
    {
        var cart = GetCartItems();
        if (cart.Count == 0)
        {
            TempData["Message"] = "Your cart is empty!";
            return RedirectToAction("Index");
        }

        // هنا يمكن إضافة منطق المعالجة مثل إرسال الطلب إلى قاعدة البيانات أو معالجة الدفع.

        TempData["Message"] = "Order placed successfully!";
        SaveCartSession(new List<CartItem>());
        return RedirectToAction("Index");
    }

}
