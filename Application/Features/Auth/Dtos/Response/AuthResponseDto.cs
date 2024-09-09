using Application.Shared;

namespace Application.Features.Auth.Dtos.Response
{
    public class AuthResponseDto : BaseResponse
    {
        public string? Token { get; set; }
        public UserDto? User { get; set; }
    }
}
