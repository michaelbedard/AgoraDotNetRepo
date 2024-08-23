using AgoraDotNet.Application.Services;
using AgoraDotNet.WebApi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AgoraDotNet.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginRequest request)
        {
            var success = await _loginService.Login(request.Username, request.Password);
            if (!success)
            {
                return Unauthorized();
            }
            return Ok();
        }
    }
}