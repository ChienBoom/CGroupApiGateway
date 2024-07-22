using CShop.Auth;
using CShop.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CShop.Controllers
{
    public class UserController : BaseController<User>
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context) : base(context)
        {
            _context = context;

        }
    }
}
