using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ResumeShop.Data;
using ResumeShop.Models;
using System.IO;
using System.Linq;

namespace ResumeShop.Pages.Admin
{
    public class EditModel : PageModel
    {
        public EshopContext _context { get; set; }

        public EditModel(EshopContext context)
        {
            _context = context;
        }
        [BindProperty]
        public AddEditProductViewModel Product { get; set; }


        public void OnGet(int id)
        {

            Product = _context.Products.Include(p => p.Item).
                Where(p => p.Id == id)
                .Select(s => new AddEditProductViewModel()
                {
                    Id = id,
                    Name = s.Name,
                    Description = s.Description,
                    QuantityInStock = s.Item.QuantityInStock,
                    Price = s.Item.Price,
                }).FirstOrDefault();


        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            var product = _context.Products.Find(Product.Id);
            var item = _context.Items.First(i => i.Id == product.ItemId);


            product.Name = Product.Name;
            product.Description = Product.Description;
            item.Price = Product.Price;
            item.QuantityInStock = Product.QuantityInStock;
            _context.SaveChanges();

            if (Product.Picture?.Length > 0)
            {
                string filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot",
                    "images",
                    product.Id + Path.GetExtension(Product.Picture.FileName));
                using (var stream = new FileStream(filepath, FileMode.Create))
                {
                    Product.Picture.CopyTo(stream);


                }
               
            }
            return RedirectToPage("Index");
        }
    }
}
