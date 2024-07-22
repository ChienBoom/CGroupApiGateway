using CShop.Auth;
using CShop.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CShop.Controllers
{
    public class CategoryController : BaseController<Category>
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
