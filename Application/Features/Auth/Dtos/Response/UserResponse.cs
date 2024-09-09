using Application.Features.Auth.Dtos;
using Application.Shared;

namespace Application.Features.Auth.Dtos.Response
{
    public class UserResponse : BaseResponse
    {
        public UserDto? Data { get; set; }
    }
}
