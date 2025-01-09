using Chat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Text;
using System.Text.Json;

namespace Chat.Controllers
{
    [Route("~/chat-api/[controller]")]
    [ApiController]
    public class ChatController : Controller
    {
        private HttpClient _httpClient;

        public ChatController(IHttpClientFactory httpClientFactory) { _httpClient = httpClientFactory.CreateClient(); }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("OK");
        }

        [HttpPost]
        [Route("chat")]
        public async Task<IActionResult> ChatAsync([FromBody] ChatRequest chatRequest)
        {
            var url = "https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent?key=AIzaSyDQ5WbPCK02MSYkSqLdsDsQNVcszxs4W4Q";
            var body = new
            {
                contents = new[]{
                    new
                    {
                        role = "user",
                        parts = new[]
                        {
                            new { text = chatRequest.question }
                        }
                    }
            }
            };
            var jsonBody = JsonSerializer.Serialize(body);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            try
            {
                var response = await _httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return Ok(responseContent);
                }
                else
                {
                    return Ok("Error");
                }
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
    }
}
