using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("")]
    public class PingController : ControllerBase
    {
        //private readonly DatabaseConnector db = new();
       

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok();
        }
    }
}