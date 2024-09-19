using Application.Abstractions;
using Application.Features.GoogleAuth;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CBT.APIs.Endpoints.GoogleAuth
{
    public class GoogleAuthEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/google/{id-token}", async (
                    [FromRoute] GoogleAuthRequestEndpoint request,
                    IMapper mapper,
                    IMediator mediator,
                    CancellationToken cancellationToken) =>
            {
                var command = mapper.Map<GoogleAuthCommand>(request);
                var response = await mediator.Send(command, cancellationToken);

                return mapper.Map< GoogleAuthResponseEndpoint> (response);
            });
        }
    }
}
