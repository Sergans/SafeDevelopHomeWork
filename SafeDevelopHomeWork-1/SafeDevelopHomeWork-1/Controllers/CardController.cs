using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SafeDevelopHomeWork_1.Controllers
{
    [Route("api/CardController")]
    [ApiController]
    public class CardController : ControllerBase
    {
       [HttpGet("get")]
       public IActionResult Get()
        {
            return Ok();
        }
    }
}
