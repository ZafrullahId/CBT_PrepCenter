using CBTPreparation_Application.Abstractions;
using CBTPreparation.APIs.Filters;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CBTPreparation.Application.Features.Auth.CreateToken;

namespace CBTPreparation.APIs.Endpoints.Auth.CreateToken
{
    public class CreateTokenEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/token/", async (
                    [FromBody] CreateTokenRequest request,
                    IMapper mapper,
                    IMediator mediator,
                    CancellationToken cancellationToken) =>
            {
                var command = mapper.Map<CreateTokenCommand>(request);
                var response = await mediator.Send(command, cancellationToken);

                return mapper.Map<CreateTokenResponse>(response);
            }).Validator<CreateTokenRequest>()
            .WithTags(EndpointSchema.Auth);
        }
    }
}

