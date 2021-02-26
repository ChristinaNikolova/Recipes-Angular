namespace Recipes.Controllers
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Net.Http;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using Recipes.Data.Models;
    using Recipes.Helpers;
    using Recipes.Models.Account.InputModels;
    using Recipes.Models.Account.ViewModels;
    using Recipes.Models.Common;

    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    public class AccountController : ApiController
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly JwtSettings jwtSettings;
        private readonly HttpClient client;

        public AccountController(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IOptions<JwtSettings> jwtSettings)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.jwtSettings = jwtSettings.Value;
            this.client = new HttpClient();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<object> Login([FromBody] LoginInputModel model)
        {
            var user = this.userManager.Users.SingleOrDefault(r => r.Email == model.Email);
            if (user is null)
            {
                return this.BadRequest(new BadRequestViewModel
                {
                    Message = "Incorrect e-mail or password.",
                });
            }

            var result = await this.signInManager.PasswordSignInAsync(user.UserName, model.Password, false, false);

            if (result.Succeeded)
            {
                return new AuthenticationViewModel
                {
                    Message = "You have successfully logged in.",
                    Token = this.GenerateJwtToken(user),
                };
            }

            return this.BadRequest(new BadRequestViewModel
            {
                Message = "Incorrect e-mail or password.",
            });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<object> Register([FromBody] RegisterInputModel model)
        {
            var user = new ApplicationUser()
            {
                Email = model.Email,
                UserName = model.Username,
            };

            if (this.userManager.Users.Any(u => u.Email == model.Email))
            {
                return this.BadRequest(new BadRequestViewModel
                {
                    Message = "This e-mail is already taken. Please try with another one.",
                });
            }

            if (this.userManager.Users.Any(u => u.UserName == model.Username))
            {
                return this.BadRequest(new BadRequestViewModel
                {
                    Message = "This username is already taken. Please try with another one.",
                });
            }

            var result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var addToRoleResult = await this.userManager.AddToRoleAsync(user, "User");
                if (addToRoleResult.Succeeded)
                {
                    await this.signInManager.SignInAsync(user, false);

                    return new AuthenticationViewModel
                    {
                        Message = "You have successfully registered.",
                        Token = this.GenerateJwtToken(user),
                    };
                }
            }

            return this.BadRequest(new BadRequestViewModel
            {
                Message = "Something went wrong. Check your form and try again",
            });
        }

        private string GenerateJwtToken(ApplicationUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.jwtSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Role, this.userManager.IsInRoleAsync(user, "Administrator").GetAwaiter().GetResult() ? "Administrator" : "User"),
                    }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
