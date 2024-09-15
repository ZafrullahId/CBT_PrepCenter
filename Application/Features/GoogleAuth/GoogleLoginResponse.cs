using Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GoogleAuth
{
    public record GoogleLoginResponse(
        string Token, 
        string RefreshToken,
        BaseResponse BaseResponse);
}
