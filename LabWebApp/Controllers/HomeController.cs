using Microsoft.AspNetCore.Mvc;
using LabWebApp.Data;

namespace LabWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products;
            return View(products);
        }
    }
}
