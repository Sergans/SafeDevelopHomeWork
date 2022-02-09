using Microsoft.AspNetCore.Http;
using SafeDevelopHomeWork_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.IdentityModel;
using Microsoft.AspNetCore.Identity;
using SafeDevelopHomeWork_1.Data;
using Microsoft.AspNetCore.Authorization;

namespace SafeDevelopHomeWork_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signManager;
        private readonly RoleManager<IdentityRole> _roleManager;
       public AccountController(UserManager<User> userManager,SignInManager<User> signInManager,RoleManager<IdentityRole> roleManager)
        {
           _userManager= userManager;
           _signManager= signInManager;    
           _roleManager= roleManager;
        }
        [HttpPost("registration")]
        [AllowAnonymous]
        public async Task<IActionResult> Registration([FromQuery]string Name,[FromQuery]string Password)
        {
            var user=new User() { UserName = Name};
            var role=new IdentityRole() { Name = "user" };
            await _roleManager.CreateAsync(role);
            var result=await _userManager.CreateAsync(user,Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, role.Name);
                return Ok("Успешно");
            }

            return Ok("Ошибка");
        }
        [HttpPost("sign")]
        [AllowAnonymous]
        public async Task<IActionResult> Sign([FromQuery] string Name, [FromQuery] string Password)
        {
            var result = await _signManager.PasswordSignInAsync(Name, Password, false,false);
            if (result.Succeeded)
            {
                return Ok("Выполнен вход");
            }

            return Ok("Неверный логин или пароль");
        }
    }
}
