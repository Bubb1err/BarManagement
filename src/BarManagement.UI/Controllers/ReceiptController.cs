using Microsoft.AspNetCore.Mvc;

namespace BarManagement.UI.Controllers
{
    public class ReceiptController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
