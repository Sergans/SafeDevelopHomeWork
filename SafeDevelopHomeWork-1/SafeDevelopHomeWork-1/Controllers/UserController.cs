using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SafeDevelopHomeWork_1.Services;
using SafeDevelopHomeWork_1.Models;
using Microsoft.AspNetCore.Authorization;

namespace SafeDevelopHomeWork_1.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
       private readonly UserOperation _userOperation;
       public UserController(UserOperation userOperation)
       {
            _userOperation= userOperation;
       }
        [HttpGet]
        public IActionResult GetAll()
        {
            if (_userOperation.GetAll().Count == 0)
                return Ok("База пуста");

            return Ok(_userOperation.GetAll()); 
        }
        [HttpPost]
        public IActionResult Add([FromQuery]string mail,[FromQuery]string password,[FromQuery]string role)
        {
            var user=new User(){ 
                Email = mail,
                Password=password,
                Role=role };
            _userOperation.AddUser(user);
            return Ok();
        }

    }
}
