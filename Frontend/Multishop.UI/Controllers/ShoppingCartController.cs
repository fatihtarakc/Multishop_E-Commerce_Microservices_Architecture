using Microsoft.AspNetCore.Mvc;

namespace Multishop.UI.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}