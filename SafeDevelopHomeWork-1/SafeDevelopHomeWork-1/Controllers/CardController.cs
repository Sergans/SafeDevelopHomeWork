using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SafeDevelopHomeWork_1.Services;
using SafeDevelopHomeWork_1.Models;

namespace SafeDevelopHomeWork_1.Controllers
{
    [Route("api/CardController")]
    [ApiController]
    public class CardController : ControllerBase
    {
       private readonly CardOperation _cardOperation;
        public CardController(CardOperation cardOperation)
        {
            _cardOperation = cardOperation;
        }
       [HttpGet("get")]
       public IActionResult Get()
        {
            return Ok(_cardOperation.GetAll());
        }
        [HttpPost("addcard")]
        public IActionResult Add([FromBody]CardModel card)
        {
            _cardOperation.AddCard(card);
            return Ok();
        }
    }
}
