using HouseholdManagerApi.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace HouseholdManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signinManager;
        public AuthController(IConfiguration config, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signinManager)
        {
            _config = config;
            this.userManager = userManager;
            this.signinManager = signinManager;
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDTO request)
        {
            var user = new IdentityUser { UserName = request.Username, Email = request.Email };
            var result = await this.userManager.CreateAsync(user, request.Password);

            return Ok();
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO payload)
        {
            //your logic for login process
            //If login usrename and password are correct then proceed to generate token

            var signinResult = await this.signinManager.PasswordSignInAsync(payload.Username, payload.Password, false, false);

            if (!signinResult.Succeeded)
            {
                return StatusCode(401);
            }

            var user = await this.userManager.FindByNameAsync(payload.Username);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetValue<string>("Jwt:Key")!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              [
                  new Claim(JwtRegisteredClaimNames.Email, user.Email),
                  new Claim(JwtRegisteredClaimNames.Name, user.UserName),
                  new Claim("userId", user.Id)
              ], 
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

            return Ok(token);
        }
    }
}
