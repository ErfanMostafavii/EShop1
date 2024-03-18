using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ResumeShop.Data;
using ResumeShop.Models;

namespace ResumeShop.Pages.Admin.ManageUsers
{
    public class IndexModel : PageModel
    {
        private readonly ResumeShop.Data.EshopContext _context;

        public IndexModel(ResumeShop.Data.EshopContext context)
        {
            _context = context;
        }

        public IList<Users> Users { get;set; }

        public async Task OnGetAsync()
        {
            Users = await _context.Users.ToListAsync();
        }
    }
}
