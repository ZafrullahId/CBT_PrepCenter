using Application.Abstractions;
using Application.Features.Auth.GetAuth;
using CBT.APIs.Filters;
using CBT_PrepCenter.Endpoints.Students.GetStudent;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CBT.APIs.Endpoints.Auth.GetToken
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

