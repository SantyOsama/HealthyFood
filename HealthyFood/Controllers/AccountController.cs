
namespace HealthyFood.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager,SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                City cityEnum;
                if (!Enum.TryParse(model.City.ToString(), out cityEnum))
                {
                    ModelState.AddModelError("City", "Invalid city selected.");
                    return View(model);
                }
                User user = new User
                {
                    FullName = model.FullName,
                    Email = model.Email,
                    UserName = model.Email,  
                    City = model.City
                };
                IdentityResult result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "user");
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Login");

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    bool passwordCorrect = await userManager.CheckPasswordAsync(user, model.Password);

                    if (passwordCorrect)
                    {
                        var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                        // await signInManager.SignInAsync(user, model.RememberMe)

                        if (result.Succeeded)
                        {
                            var roles = await userManager.GetRolesAsync(user);

                            if (roles.Contains("Admin"))
                            {
                                return RedirectToAction("Dashboard", "Admin");
                            }

                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Incorrect password.");
                        return View(model);
                    }
                }
                ModelState.AddModelError("Email", "Email not found.");
            }
            return View(model);
        }

    }
}
