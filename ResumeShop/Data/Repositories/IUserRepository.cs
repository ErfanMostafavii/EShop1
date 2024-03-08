using Microsoft.EntityFrameworkCore.Internal;
using ResumeShop.Models;
using System.Linq;

namespace ResumeShop.Data.Repositories
{
    public interface IUserRepository
    {

        bool isExistUserByEmail(string email);
        void AddUser(Users user);

        Users GetUserForLogin(string email,string password);
        
    }

    public class UserRepository : IUserRepository
    {
        EshopContext _context;
        public UserRepository(EshopContext context)
        {
            _context = context;
        }

        public bool isExistUserByEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }
        public void AddUser(Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public Users GetUserForLogin(string email, string password)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email && u.password == password);
        }
    }
}
