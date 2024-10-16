using CBTPreparation.Application.Features.GoogleAuth;
using CBTPreparation_Application.Abstractions;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CBTPreparation.APIs.Endpoints.GoogleAuth
{
    public class GoogleAuthEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/google/{id-token}", async (
                    [AsParameters] GoogleAuthRequestEndpoint request,
                   [FromServices] IMapper mapper,
                    [FromServices] IMediator mediator,
                    CancellationToken cancellationToken) =>
            {
                var command = mapper.Map<GoogleAuthCommand>(request);
                var response = await mediator.Send(command, cancellationToken);

                return mapper.Map< GoogleAuthResponseEndpoint> (response);
            });
        }
    }
}
