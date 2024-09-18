using Application.Abstractions;
using Application.Features.Auth.GetAuth;
using CBT.APIs.Filters;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CBT.APIs.Endpoints.Auth.GetToken
{
    public class GetRefreshTokenEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("token/refresh/", async (
                    [FromBody] GetRefreshTokenRequest request,
                    IMapper mapper,
                    IMediator mediator,
                    CancellationToken cancellationToken) =>
            {
                var command = mapper.Map<GetTokenQuery>(request);
                var response = await mediator.Send(command, cancellationToken);

                return mapper.Map<GetRefreshTokenResponse>(response);
            }).Validator<GetTokenRequest>()
            .WithTags(EndpointSchema.Auth);
        }
    }
}

