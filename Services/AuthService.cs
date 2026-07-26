using FAD_TASK.Data;
using FAD_TASK.DTOs;

namespace FAD_TASK.Services
{
    public class AuthService : IAuthService
    {
        public LoginResponseDto Authenticate(LoginRequestDto request)
        {
            if (request == null)
            {
                return new LoginResponseDto
                {
                    IsSuccess = false,
                    Message = "Request data is required."
                };
            }

            // Simple junior-friendly comparison of credentials against in-memory user
            if (request.Email == FakeDatabase.FakeUserEmail && request.Password == FakeDatabase.FakeUserPassword)
            {
                return new LoginResponseDto
                {
                    IsSuccess = true,
                    Message = "Login successful"
                };
            }

            return new LoginResponseDto
            {
                IsSuccess = false,
                Message = "Invalid email or password"
            };
        }
    }
}
