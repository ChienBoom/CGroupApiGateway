using CShop.Auth;
using CShop.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CShop.Controllers
{
    public class OrderController : BaseController<Order>
    {
        private readonly AppDbContext _context;

        public OrderController(AppDbContext context) : base(context)
        {
            _context = context;

        }
    }
}