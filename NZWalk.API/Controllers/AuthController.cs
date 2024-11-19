using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalk.API.Models.DTO;

namespace NZWalk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {

            _userManager = userManager;
        }

        //POST:api/auth/Register

        [HttpPost]
        [Route("Register")]

        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            var user = new IdentityUser
            {
                UserName = registerRequestDTO.UserName,
                Email = registerRequestDTO.UserName
            };
           var  IdentityResult = await this._userManager.CreateAsync(user, registerRequestDTO.Password);
            if (IdentityResult.Succeeded)
            {
                // want Add roles to this user
                IdentityResult= await this._userManager.AddToRolesAsync(user, registerRequestDTO.Roles);
                if (IdentityResult.Succeeded)
                {
                    return Ok("User was Registered Please Login");
                }

            }
            return BadRequest("Some thing Went Wrong");

        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var user = await this._userManager.FindByEmailAsync(loginRequestDTO.UserName);
            if (user != null)
            {
                var CheckPasswordResult = await this._userManager.CheckPasswordAsync(user, loginRequestDTO.Password);
                    if (CheckPasswordResult)
                {

                    return Ok();
                }
            }
            return BadRequest("Some thing Went Wrong");
        }
    }
}
