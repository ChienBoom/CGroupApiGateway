using CShop.Auth;
using CShop.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CShop.Controllers
{
    public class OrderDetailController : BaseController<OrderDetail>
    {
        private readonly AppDbContext _context;

        public OrderDetailController(AppDbContext context) : base(context)
        {
            _context = context;

        }
    }
}
