using Microsoft.AspNetCore.Mvc;
using ResumeShop.Data;
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
            return View("/Views/Component/ProductGroupsComponent.cshtml", _context.categories);
        }
    }
}
