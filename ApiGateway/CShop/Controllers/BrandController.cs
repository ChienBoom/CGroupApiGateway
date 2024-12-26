using CShop.Auth;
using CShop.Entities;
using CShop.EventHandle;
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

        [HttpGet("/testSendMessage")]
        public async Task<IActionResult> TestSendMessage(string message)
        {
            var producer = new EventProducer();
            var mes = producer.SendMessage(message);
            return Ok(mes);
        }

        [HttpGet("/testReceiveMessage")]
        public async Task<IActionResult> TestReceiveMessage()
        {
            var consummer = new EventConsumer();
            var mes = consummer.ReceiveMessage();
            return Ok(mes);
        }

    }
}
