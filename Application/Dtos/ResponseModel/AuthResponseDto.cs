using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ResponseModel
{
    public class AuthResponseDto
    {
        public string? Token {  get; set; }
        public UserDto? User { get; set; }
    }
}
