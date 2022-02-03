﻿using Microsoft.AspNetCore.Http;
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
        [HttpGet("get")]
        [Authorize]
        public IActionResult GetAll()
        {
            
            if (_userOperation.GetAll().Count == 0)
                return Ok("База пуста");

            return Ok(_userOperation.GetAll()); 
        }
        [HttpPost("add")]
        public IActionResult Add([FromQuery]string mail,[FromQuery]string password,[FromQuery]string role)
        {
            var user=new User(){ 
                Email = mail,
                Password=password,
                Role=role };
            _userOperation.AddUser(user);
            return Ok();
        }
        [HttpPost("sign")]
        [AllowAnonymous]
        public IActionResult Aurorize([FromQuery] string mail, [FromQuery] string password)
        {
            var user = _userOperation.Autorize(mail, password);
            if (user == null)
            return Ok("Пользователя нет");

            return Ok(user);

        }

    }
}
