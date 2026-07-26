using FAD_TASK.DTOs;

namespace FAD_TASK.Services
{
    public interface IAuthService
    {
        LoginResponseDto Authenticate(LoginRequestDto request);
    }
}
