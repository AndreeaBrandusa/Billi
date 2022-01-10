using BilliWebApp.Data;
using BilliWebApp.Models.Identity;

namespace BilliWebApp.Services
{
    public class IdentityService
    {
        private ApplicationDbContext _context;

        public IdentityService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Login(LoginModel model) 
        {
            return true;
        }
    }
}
