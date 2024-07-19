using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CShop.Controllers
{
    [Authorize]
    [Route("~/cshop-api/[controller]")]
    [ApiController]
    public class CShopController : ControllerBase
    {
        private readonly ILogger<CShopController> _logger;

        public CShopController(ILogger<CShopController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("first")]
        public string First()
        {
            return "CSHOP SERVICE - FIRST";
        }

        [HttpGet]
        [Route("second")]
        public string Second()
        {
            return "CSHOP SERVICE - SECOND";
        }
    }
}
