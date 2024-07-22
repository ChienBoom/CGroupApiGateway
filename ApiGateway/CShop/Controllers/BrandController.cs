using CShop.Auth;
using CShop.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CShop.Controllers
{
    public class BrandController : BaseController<Brand>
    {
        private readonly AppDbContext _context;

        public BrandController(AppDbContext context) : base(context) { 
            _context = context;
        }

        //[HttpGet("{id}")]
        //public override async Task<ActionResult<Brand>> Get(int id)
        //{
        //    var product = await _context.Brand
        //                                .Include(p => p.P) // giả sử có một liên kết đến Category
        //                                .FirstOrDefaultAsync(p => p.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(product);
        //}

    }
}
