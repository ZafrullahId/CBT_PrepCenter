using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ResponseModel
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
