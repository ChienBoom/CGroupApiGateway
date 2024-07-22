using CShop.Auth;
using CShop.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CShop.Controllers
{
    public class ProductDetailController : BaseController<ProductDetail>
    {
        private readonly AppDbContext _context;

        public ProductDetailController(AppDbContext context) : base(context)
        {
            _context = context;

        }
    }
}
