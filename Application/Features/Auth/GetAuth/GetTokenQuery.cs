using MediatR;


namespace CBTPreparation.Application.Features.Auth.GetAuth
{
    public record GetTokenQuery(string Email,  string Password) : IRequest<GetTokenQueryResponse>;
}
