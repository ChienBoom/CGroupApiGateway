using Chat.Models;
using Chat.Services;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Controllers
{
    [Route("~/chat-api/[controller]")]
    [ApiController]
    public class MailController : Controller
    {
        private readonly MailService _mailService;

        public MailController(MailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost("send-email")]
        public async Task<IActionResult> SendEmail([FromBody] MailRequest request)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            //await _mailService.SendEmailAsync(request.ToEmail, request.Subject, request.Body);
            //return Ok("Email sent successfully.");
            return Ok();
        }
    }
}
