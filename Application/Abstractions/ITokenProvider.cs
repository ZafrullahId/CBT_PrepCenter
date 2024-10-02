using Domain.Entity;

namespace CBTPreparation.Application.Abstractions
{
    public interface ITokenProvider
    {
        (string Token, string RefreshToken) Create(User user);
    }
}