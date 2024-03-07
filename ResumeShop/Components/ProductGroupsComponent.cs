using Microsoft.AspNetCore.Mvc;
using ResumeShop.Data;
using ResumeShop.Data.Repositories;
using ResumeShop.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeShop.Components
{
    public class ProductGroupsComponent : ViewComponent
    {

        private IGroupRepository _groupRepository;
        public ProductGroupsComponent(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }




        public async Task<IViewComponentResult> InvokeAsync()
        { 

            return View("/Views/Component/ProductGroupsComponent.cshtml", _groupRepository.GetGroupForShowGroup());
        }
    }
}
