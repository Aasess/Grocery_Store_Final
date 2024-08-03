using Grocery_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Grocery_Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly GroceryDbContext _context;
        public HomeController(GroceryDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var items = _context.Items.Include(i => i.Category).ToList();
            ViewBag.Items = items; 
            return View();
        }

        public IActionResult Detail(int id)
        {
            var item = _context.Items.Include(i => i.Category).FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
