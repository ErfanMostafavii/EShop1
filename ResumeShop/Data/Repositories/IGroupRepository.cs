using ResumeShop.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ResumeShop.Data.Repositories
{
    public interface IGroupRepository
    {

        IEnumerable<Category> GetAllCategories();
        IEnumerable<ShowGroupViewModel> GetGroupForShowGroup();

    }
    public class GroupRepository : IGroupRepository
    {

        private EshopContext _context;
        public GroupRepository( EshopContext context)
        {
            _context = context;           
        }

        public IEnumerable<Category> GetAllCategories()
        {

            return _context.categories;

        }



        public IEnumerable<ShowGroupViewModel> GetGroupForShowGroup()
        {
           return  _context.categories
                .Select(c => new ShowGroupViewModel
                {
                    Name = c.Name,
                    GroupId = c.Id,
                    ProductCount = _context.CategoryToProducts.Count(g => g.CategoryId == c.Id)
                }).ToList();
        }
    }


}
