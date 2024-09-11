using Domain.Entity;

namespace Application.Abstractions
{
    public interface ITokenProvider
    {
        (string Token, string RefreshToken) Create(User user);
    }
}