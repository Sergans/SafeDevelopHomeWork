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
            if (_cardOperation.GetAll().Count == 0)
                return Ok("База пуста");

            return Ok(_cardOperation.GetAll());
        }
        [HttpPost("details")]
        public IActionResult Details([FromBody] CardModel card)
        {
            if (_cardOperation.GetAll().Count == 0)
                return Ok("База пуста");

            var _card=_cardOperation.GetById(card.Id);
            if (_card == null)
                return Ok("Записей нет");

            return Ok(_card);
        }

        [HttpPost("addcard")]
        public IActionResult Add([FromBody]CardModel card)
        {
            _cardOperation.AddCard(card);
            return Ok();
        }
        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery]int id)
        {
            if (_cardOperation.GetAll().Count == 0)
                return Ok("База пуста");

            var _card = _cardOperation.GetById(id);
            if (_card == null)
                return Ok("Записей нет");

            _cardOperation.Delete(id);
            return Ok($"{_card.Famaly}- удален");
        }
        [HttpPut("update")]
        public IActionResult UpDate([FromQuery] int id)
        {
            if (_cardOperation.GetAll().Count == 0)
                return Ok("База пуста");

            var _card = _cardOperation.GetById(id);
            if (_card == null)
                return Ok("Записей нет");

            _cardOperation.Delete(id);
            return Ok($"{_card.Famaly}- удален");
        }
    }
}
