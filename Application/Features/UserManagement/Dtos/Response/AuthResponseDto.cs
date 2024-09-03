using Application.Shared;

namespace Application.Features.UserManagement.Dtos.ResponseModel
{
    public class AuthResponseDto : BaseResponse
    {
        public string? Token { get; set; }
        public UserDto? User { get; set; }
    }
}
