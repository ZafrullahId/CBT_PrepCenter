using CBTPreparation.Domain.UserAggregate;

namespace CBTPreparation.Application.Abstractions
{
    public interface ITokenProvider
    {
        (string Token, string RefreshToken) Create(User user);
    }
}