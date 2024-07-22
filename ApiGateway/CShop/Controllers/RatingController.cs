using CShop.Auth;
using CShop.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CShop.Controllers
{
    public class RatingController : BaseController<Rating>
    {
        private readonly AppDbContext _context;

        public RatingController(AppDbContext context) : base(context)
        {
            _context = context;

        }
    }
}
