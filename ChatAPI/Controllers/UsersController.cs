using System.Linq;
using ChatAPI.Auth;
using ChatAPI.Context;
using ChatAPI.Models.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChatAPI.Controllers
{
    [Produces("application/json")]
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(string Login, string Pass)
        {
            var user = _userService.Authenticate(Login, Pass);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user.Tokens);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users =  _userService.GetAll();
            return Ok(users);
        }
    }
}