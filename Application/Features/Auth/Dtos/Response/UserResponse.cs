using Application.Shared;

namespace Application.Features.UserManagement.Dtos.ResponseModel
{
    public class UserResponse : BaseResponse
    {
        public UserDto? Data { get; set; }
    }

    public class UsersResponse : BaseResponse
    {
        public List<UserDto>? Data { get; set; }

    }
}
