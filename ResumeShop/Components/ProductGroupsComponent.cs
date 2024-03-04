using Microsoft.AspNetCore.Mvc;
using ResumeShop.Data;
using ResumeShop.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeShop.Components
{
    public class ProductGroupsComponent : ViewComponent
    {

        private EshopContext _context;


        public ProductGroupsComponent(EshopContext context)
        {
            _context = context;            
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = _context.categories
                .Select(c => new ShowGroupViewModel
                {
                    Name = c.Name,
                    GroupId = c.Id,
                    ProductCount = _context.CategoryToProducts.Count(g => g.CategoryId == c.Id)
                }).ToList();
            return View("/Views/Component/ProductGroupsComponent.cshtml", categories);
        }
    }
}
