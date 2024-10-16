using CBTPreparation_Application.Abstractions;
using CBTPreparation.APIs.Filters;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CBTPreparation.Application.Features.Auth.GetAuth;
using CBTPreparation.APIs.Endpoints.Auth.GetRefreshToken;

namespace CBTPreparation.APIs.Endpoints.Auth.UpdateToken
{
    public class GetRefreshTokenEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("token/refresh/", async (
                    [FromBody] GetRefreshTokenRequest request,
                    [FromServices] IMapper mapper,
                    [FromServices] IMediator mediator,
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

