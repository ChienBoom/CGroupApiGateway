using Microsoft.AspNetCore.Mvc;

namespace CCinemal.Controllers
{
    [Route("~/ccinemal-api/[controller]")]
    [ApiController]
    public class CCinemalController : ControllerBase
    {
        private readonly ILogger<CCinemalController> _logger;

        public CCinemalController(ILogger<CCinemalController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("first")]
        public string First()
        {
            return "CCINEMAL SERVICE - FIRST";
        }

        [HttpGet]
        [Route("second")]
        public string Second()
        {
            return "CCINEMAL SERVICE - SECOND";
        }
    }
}
