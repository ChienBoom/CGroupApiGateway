using CShop.Auth;
using CShop.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CShop.Controllers
{
    public class EvaluateController : BaseController<Evaluate>
    {
        private readonly AppDbContext _context;

        public EvaluateController(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
