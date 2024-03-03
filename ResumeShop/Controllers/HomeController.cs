using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ResumeShop.Data;
using ResumeShop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private EshopContext _context { get; set; }

        private static Cart _cart = new Cart();


        public HomeController(ILogger<HomeController> logger, EshopContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }


        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Detail(int id)
        {
            var product = _context.Products
                .Include(p => p.Item).SingleOrDefault(p => p.Id ==id);
            if (product == null)
            {
                return NotFound();
            }
            var categories = _context.Products
                .Where(p => p.Id == id)
                .SelectMany(c => c.categoryToProducts)
                .Select(ca => ca.Category)
                .ToList();

            var vm = new DetailsViewModel()
            {
                Product = product,
                Categories = categories
            };

            return View(vm);
        }

        public IActionResult AddToCart(int itemId)
        {
            var product = _context.Products.Include(p => p.Item).SingleOrDefault(p => p.ItemId == itemId);
            if (product != null)
            {
                var cartItem = new CartItem()
                {
                    Item = product.Item,
                    Quantity = 1,
                };
                _cart.AddCartItem(cartItem);    
            }
            return RedirectToAction("ShowCart");
        }

        public IActionResult ShowCart()
        {
            var CartVM = new CartViewModel()
            {
                CartItems = _cart.CartItems,
                OrderTotal = _cart.CartItems.Sum(c => c.getTotalPrice())

            };
            return View(CartVM);
        }

        public IActionResult RemoveCart(int itemId)
        {
            _cart.RemoveCartItem(itemId);
            return RedirectToAction("ShowCart");
        }

        [Route("ContactUs")]
        public IActionResult ContactUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
