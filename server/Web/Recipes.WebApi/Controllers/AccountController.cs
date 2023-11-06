﻿namespace Recipes.WebApi.Controllers
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using Recipes.Common;
    using Recipes.Data.Models;
    using Recipes.Web.Models.Account.InputModels;
    using Recipes.Web.Models.Common.Account.ViewModels;
    using Recipes.Web.Models.Common.ViewModels;
    using Recipes.WebApi.Helpers;

    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    public class AccountController : ApiController
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly JwtSettings jwtSettings;

        public AccountController(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IOptions<JwtSettings> jwtSettings)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.jwtSettings = jwtSettings.Value;
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
                    Message = Messages.IncorrectCredentials,
                });
            }

            var result = await this.signInManager.PasswordSignInAsync(user.UserName, model.Password, false, false);
            var isAdmin = user.UserName == "Admin";

            if (result.Succeeded)
            {
                return new AuthenticationViewModel
                {
                    Username = user.UserName,
                    Message = Messages.SuccessfulLogin,
                    Token = this.GenerateJwtToken(user),
                    IsAdmin = isAdmin,
                };
            }

            return this.BadRequest(new BadRequestViewModel
            {
                Message = Messages.IncorrectCredentials,
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
                    Message = Messages.InvalidEmail,
                });
            }

            if (this.userManager.Users.Any(u => u.UserName == model.Username))
            {
                return this.BadRequest(new BadRequestViewModel
                {
                    Message = Messages.InvalidUsername,
                });
            }

            var result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var addToRoleResult = await this.userManager.AddToRoleAsync(user, GlobalConstants.User);
                if (addToRoleResult.Succeeded)
                {
                    await this.signInManager.SignInAsync(user, false);

                    return new AuthenticationViewModel
                    {
                        Username = model.Username,
                        Message = Messages.SuccessfulRegister,
                        Token = this.GenerateJwtToken(user),
                    };
                }
            }

            return this.BadRequest(new BadRequestViewModel
            {
                Message = Messages.UnknownError,
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
                        new Claim(ClaimTypes.Role, this.userManager.IsInRoleAsync(user, GlobalConstants.AdminName).GetAwaiter().GetResult() ? GlobalConstants.AdminName : GlobalConstants.User),
                    }),
                Expires = DateTime.UtcNow.AddDays(GlobalConstants.DefaultDaysExpiredToken),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
