using CBTPreparation_Application.Abstractions;
using CBTPreparation.APIs.Filters;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CBTPreparation.APIs.Endpoints.Auth.GetRefreshToken;
using CBTPreparation.APIs.Endpoints.Auth.CreateToken;
using CBTPreparation.Application.Features.Auth.CreateToken;

namespace CBTPreparation.APIs.Endpoints.Auth.UpdateToken
{
    public class CreateRefreshTokenEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("token/refresh/", async (
                    [FromBody] CreateRefreshTokenRequest request,
                    IMapper mapper,
                    IMediator mediator,
                    CancellationToken cancellationToken) =>
            {
                var command = mapper.Map<CreateTokenCommand>(request);
                var response = await mediator.Send(command, cancellationToken);

                return mapper.Map<CreateRefreshTokenResponse>(response);
            }).Validator<CreateTokenRequest>()
            .WithTags(EndpointSchema.Auth);
        }
    }
}

