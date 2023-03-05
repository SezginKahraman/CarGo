using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.JWT;
using Core.Utilities.Security.JWT.Abstract;
using Entity.Concrete.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;
        IUserService _userService;
        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }
    
        [HttpPost]
        [Route("register")]
        public IActionResult Register(UserForRegisterDto userRegister)
        {
            var isRegisterSuccess = _authService.Register(userRegister);
            if (isRegisterSuccess.Success)
            {
                var accessToken = _authService.CreateToken(isRegisterSuccess.Data);
                return Ok(accessToken.Data.Token);

            }
            return BadRequest();

        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var isLoginSuccess = _authService.Login(userForLoginDto);
            if (isLoginSuccess.Success)
            {
                var accessToken = _authService.CreateToken(isLoginSuccess.Data);
                return Ok(accessToken.Data.Token);

            }
            return BadRequest();
        }
        [HttpPost]
        [Route("test")]
        public IActionResult GetUserDetails(int id)
        {
            var allUsersDetails = _userService.GetAllUsersDetails();
            var specificDetails = _userService.GetUserDetailsById(id);
            return Ok();
            return BadRequest();
        }
    }
}
