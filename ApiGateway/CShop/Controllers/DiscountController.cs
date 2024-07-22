using CShop.Auth;
using CShop.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CShop.Controllers
{
    public class DiscountController : BaseController<Discount>
    {
        private readonly AppDbContext _context;

        public DiscountController(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
