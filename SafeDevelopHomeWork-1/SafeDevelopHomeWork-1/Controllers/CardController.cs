using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SafeDevelopHomeWork_1.Models;
using SafeDevelopHomeWork_1.Services;

namespace SafeDevelopHomeWork_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly CardOperation _cardOperation;
        public CardController(CardOperation cardOperation)
        {
            _cardOperation = cardOperation;
        }
        [HttpGet("getcards")]

        public IActionResult Get()
        {
            return Ok(_cardOperation.GetAll()); 
        }
        [HttpPost("addcard")]
        public IActionResult AddCard([FromBody]CardModel card)
        {
            _cardOperation.Create(card);
            return Ok();
        }
        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery]int id)
        {
            _cardOperation.Delete(id);  
            return Ok();
        }
    }
}
