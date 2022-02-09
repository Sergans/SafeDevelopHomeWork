using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SafeDevelopHomeWork_1.Models;
using Microsoft.AspNetCore.Authorization;
using SafeDevelopHomeWork_1.Services;

namespace SafeDevelopHomeWork_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserOperation _userOperation;
        public UserController(UserOperation userOperation)
        {
            _userOperation = userOperation;
        }
        [HttpGet("getusers")]
        [Authorize(Roles ="admin")]
        public IActionResult Get()
        {
            return Ok(_userOperation.GetAll());
        }
           
        
    }
}
