using Microsoft.AspNetCore.Http;
using SafeDevelopHomeWork_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.IdentityModel;
using Microsoft.AspNetCore.Identity;



namespace SafeDevelopHomeWork_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signManager;
        private readonly RoleManager<User> _roleManager;
        AccountController(UserManager<User> userManager,SignInManager<User> signInManager,RoleManager<User> roleManager)
        {
           _userManager= userManager;
           _signManager= signInManager;    
           _roleManager= roleManager;
        }
        [HttpPost]
        public async Task<IActionResult> Registration([FromQuery]string Name,[FromQuery]string Password,[FromQuery]string Role)
        {
            var user=new User() { UserName = Name};
            var role=new IdentityRole() { Name = Role };
            await _roleManager.CreateAsync(role);
            var result=await _userManager.CreateAsync(user,Password);
            if (result.Succeeded)
            {
                return Ok("Успешно");
            }

            return Ok("Ошибка");
        }
    }
}
