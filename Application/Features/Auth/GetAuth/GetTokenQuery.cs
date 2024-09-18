using MediatR;


namespace Application.Features.Auth.GetAuth
{
    public record GetTokenQuery(string Email,  string Password) : IRequest<GetTokenQueryResponse>;
}
