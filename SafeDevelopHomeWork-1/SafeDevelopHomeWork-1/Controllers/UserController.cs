using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SafeDevelopHomeWork_1.Models;
using Microsoft.AspNetCore.Authorization;


namespace SafeDevelopHomeWork_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        public UserController(UserManager<User> userManager)
        {
          _userManager = userManager;
        }
        [HttpGet("getusers")]
        [Authorize(Roles ="admin")]
        public IActionResult Get()
        {
            return Ok(_userManager.Users);
        }
        [HttpDelete]
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> Delete([FromQuery] string Name)
        {
            var user=await _userManager.FindByNameAsync(Name);
            if (user == null)
            {
                return Ok("Пользователь не найден");
            }
            await _userManager.DeleteAsync(user);
            return Ok($"{user.UserName} удален");
        }
        [HttpPost("details")]
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> Details([FromQuery]string Name)
        {
            var user = await _userManager.FindByNameAsync(Name);
            if (user == null)
            {
                return Ok("Пользователь не найден");
            }

            return Ok(user);
        }
        [HttpPut("setrole")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> SetRole([FromQuery] string Name,[FromQuery]string newRole)
        {
            var user = await _userManager.FindByNameAsync(Name);
            if (user == null)
            {
                return Ok("Пользователь не найден");
            }
            await _userManager.AddToRoleAsync(user, newRole);
            return Ok($"Пользователю {user.UserName} добавлена роль {newRole}");
        }


    }
}
