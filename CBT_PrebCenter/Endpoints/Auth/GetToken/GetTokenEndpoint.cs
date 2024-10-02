using CBTPreparation_Application.Abstractions;
using CBTPreparation.APIs.Filters;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CBTPreparation.Application.Features.Auth.GetAuth;

namespace CBTPreparation.APIs.Endpoints.Auth.GetRefreshToken
{
    public class GetTokenEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/token/", async (
                    [FromBody] GetTokenRequest request,
                    IMapper mapper,
                    IMediator mediator,
                    CancellationToken cancellationToken) =>
            {
                var command = mapper.Map<GetTokenQuery>(request);
                var response = await mediator.Send(command, cancellationToken);

                return mapper.Map<GetTokenResponse>(response);
            }).Validator<GetTokenRequest>()
            .WithTags(EndpointSchema.Auth);
        }
    }
}

