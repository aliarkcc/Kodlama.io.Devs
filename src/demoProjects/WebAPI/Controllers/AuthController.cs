using Application.Features.Users.Commands.RegisterUser;
using Application.Features.Users.Dtos;
using Application.Features.Users.Queries.LoginUser;
using Core.Security.Dtos;
using Core.Security.JWT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("regiser")]
        public async Task<IActionResult> Register([FromQuery] UserForRegisterDto userForRegisterDto)
        {
            RegisterUserCommand registerUserCommand = new() { UserForRegisterDto = userForRegisterDto };
            CreatedUserDto result = await Mediator.Send(registerUserCommand);
            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromQuery] UserForLoginDto userForLoginDto)
        {
            LoginUserQuery loginUserQuery= new() { UserForLoginDto= userForLoginDto};
            AccessToken result = await Mediator.Send(loginUserQuery);
            return Ok(result);
        }
    }
}
