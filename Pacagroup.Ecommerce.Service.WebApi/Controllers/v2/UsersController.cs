using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Pacagroup.Ecommerce.Aplication.Dto;
using Pacagroup.Ecommerce.Aplication.Interface;
using Pacagroup.Ecommerce.Service.WebApi.Helpers;
using Pacagroup.Ecommerce.Transversal.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Pacagroup.Ecommerce.Service.WebApi.Controllers.v2
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class UsersController : Controller
    {
        private readonly IUserAplication _userAplication;
        private readonly AppSettings _appSetting;
        public UsersController(IUserAplication userAplication, IOptions<AppSettings> appSetting)
        {
            _userAplication = userAplication;
            _appSetting = appSetting.Value;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody] UserDto userDto)
        {
            var response = _userAplication.Authenticate(userDto.UserName, userDto.Password);
            if (response.IsSuccess)
            {
                if (response.Data != null)
                {
                    response.Data.Token = BuildToken(response);
                    return Ok(response);
                }
                else
                    return NotFound(response);
            }
            return BadRequest(response);
        }

        private string BuildToken(Response<UserDto> usersDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSetting.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usersDto.Data.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512),
                Issuer = _appSetting.Issuer,
                Audience = _appSetting.Audience
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}
