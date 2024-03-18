using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResumeShop.Data;
using ResumeShop.Models;
using System.IO;
using System.Linq;

namespace ResumeShop.Pages.Admin
{
    public class DeleteModel : PageModel
    {
        public EshopContext _context { get; set; }
        public DeleteModel(EshopContext Context)
        {
            _context = Context;
        }


        [BindProperty]
        public Product Product { get; set; }
       
        public void OnGet(int id)
        {
            Product = _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public IActionResult OnPost(int id)
        {
            var product = _context.Products.Find(Product.Id);
            var item = _context.Items.First(p => p.Id == product.ItemId);
            _context.Items.Remove(item);
            _context.Products.Remove(product);
            _context.SaveChanges(); 
            string filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot",
                    "images",
                    product.Id + ".jpg");
            if (System.IO.File.Exists(filepath))
            {
               System.IO.File.Delete(filepath);  
            }
            return RedirectToPage("Index");
        }
    }
}
