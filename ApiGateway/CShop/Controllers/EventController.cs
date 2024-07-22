using CShop.Auth;
using CShop.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CShop.Controllers
{
    public class EventController : BaseController<Event>
    {
        private readonly AppDbContext _context;

        public EventController(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
