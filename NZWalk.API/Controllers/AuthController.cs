using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalk.API.Models.DTO;
using NZWalk.API.Repositories;

namespace NZWalk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager,ITokenRepository tokenRepository, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.tokenRepository = tokenRepository;
        }
        //POSt :/api/Auth/Register

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            var user = new IdentityUser
            {
                UserName = registerRequestDTO.UserName,
                Email = registerRequestDTO.UserName
            };
          
            var IdentityResult = await this.userManager.CreateAsync(user, registerRequestDTO.Password);
            if (IdentityResult.Succeeded)
            {
                // want Add roles to this user
                IdentityResult = await this.userManager.AddToRolesAsync(user, registerRequestDTO.Roles);
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
            var user = await this.userManager.FindByEmailAsync(loginRequestDTO.UserName);
            if (user != null)
            {
                var CheckPasswordResult = await this.userManager.CheckPasswordAsync(user, loginRequestDTO.Password);
                if (CheckPasswordResult)
                {
                    //Get roles for this user
                    var roles = await userManager.GetRolesAsync(user);
                    if (roles != null)
                    {
                        var jwttoken = this.tokenRepository.CreateJWTToken(user, roles.ToList());
                        var response = new LoginResponseDTO
                        {
                            JwtToken = jwttoken,
                        };

                        return Ok(response);
                    }
                }
            }
            return BadRequest("Some thing Went Wrong");
        }
    }
}

