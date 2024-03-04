using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResumeShop.Data;
using System.Linq;

namespace ResumeShop.Controllers
{
    public class ProductController : Controller
    {
        private EshopContext _context;

        public ProductController(EshopContext context)
        {
            _context = context;
        }
        [Route("/Group/{id}/{name}")]
        public IActionResult ShowProductByGroupId(int id, string name)
        {
            ViewData["GroupName"] = name;
            var products = _context.CategoryToProducts.Where(c => c.CategoryId == id)
                .Include(p => p.Product).Select(c => c.Product)
                .ToList();
            return View(products);
        }
    }
}
