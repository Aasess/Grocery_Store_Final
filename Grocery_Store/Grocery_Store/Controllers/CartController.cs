using Grocery_Store.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Grocery_Store.Controllers
{
    public class CartController : Controller
    {
        private readonly GroceryDbContext _context;

        public CartController(GroceryDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }
        [HttpPost]
        public IActionResult AddToCart(int id, int quantity)
        {
            var item = _context.Items.Include(i => i.Category).FirstOrDefault(i => i.Id == id);
            if (item == null) return NotFound();

            // Format price
            var formattedPrice = item.Price.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));

            var cart = GetCart();
            cart.AddItem(item, quantity);
            SaveCart(cart);

            // You can pass formattedPrice to the view if needed
            ViewBag.FormattedPrice = formattedPrice;

            return RedirectToAction("Index");
        }



        public IActionResult RemoveFromCart(int id)
        {
            var cart = GetCart();
            cart.RemoveItem(id);
            SaveCart(cart);

            return RedirectToAction("Index");
        }

        private Cart GetCart()
        {
            var cart = HttpContext.Session.Get<Cart>("Cart") ?? new Cart();
            return cart;
        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.Set("Cart", cart);
        }
    }
}
