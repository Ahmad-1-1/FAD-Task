using Microsoft.AspNetCore.Mvc;
using FAD_TASK.DTOs;
using FAD_TASK.Services;

namespace FAD_TASK.Controllers
{
    [ApiController]
    [Route("login")] // To map POST /login
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequestDto request)
        {
            // Basic validation
            if (request == null || string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(new LoginResponseDto 
                { 
                    IsSuccess = false, 
                    Message = "Email and Password are required." 
                });
            }

            var result = _authService.Authenticate(request);

            if (result.IsSuccess)
            {
                return Ok(result); // 200 OK
            }

            return Unauthorized(result); // 401 Unauthorized
        }
    }
}
