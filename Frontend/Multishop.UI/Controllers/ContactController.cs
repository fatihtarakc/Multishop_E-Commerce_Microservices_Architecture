using Microsoft.AspNetCore.Mvc;

namespace Multishop.UI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}