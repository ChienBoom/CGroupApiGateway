using CShop.Auth;
using CShop.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CShop.Controllers
{
    public class SupplierController : BaseController<Supplier>
    {
        private readonly AppDbContext _context;

        public SupplierController(AppDbContext context) : base(context)
        {
            _context = context;

        }
    }
}
