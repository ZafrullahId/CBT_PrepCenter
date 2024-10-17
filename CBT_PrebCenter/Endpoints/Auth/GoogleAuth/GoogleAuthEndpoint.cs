using CBTPreparation.APIs.Endpoints.Auth.CreateToken;
using CBTPreparation.APIs.Filters;
using CBTPreparation.Application.Features.GoogleAuth;
using CBTPreparation_Application.Abstractions;
using MapsterMapper;
using MediatR;

namespace CBTPreparation.APIs.Endpoints.Auth.GoogleAuth
{
    public class GoogleAuthEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/token/google/{token-id}", async (
                    [AsParameters] GoogleAuthRequest request,
                    IMapper mapper,
                    IMediator mediator,
                    CancellationToken cancellationToken) =>
            {
                var command = mapper.Map<GoogleAuthCommand>(request);
                var response = await mediator.Send(command, cancellationToken);

                return mapper.Map<GoogleAuthCommandResponse>(response);
            }).Validator<CreateTokenRequest>()
            .WithTags(EndpointSchema.Auth);
        }
    }
}
