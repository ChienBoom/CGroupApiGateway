using CShop.Auth;
using CShop.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CShop.Controllers
{
    public class ProductController : BaseController<Product>
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context) : base(context)
        {
            _context = context;

        }
    }
}
