using Application.Abstractions;
using Application.Features.Students.GetStudents;
using MapsterMapper;
using MediatR;

namespace CBT_PrepCenter.Endpoints.Students.GetStudents
{
    public class GetStudentsEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/articles/", async (
                    [AsParameters] GetStudentsRequest request,
                    IMapper mapper,
                    IMediator mediator,
                    CancellationToken cancellationToken) =>
            {
                var command = mapper.Map<GetStudentsQuery>(request);
                var result = await mediator.Send(command, cancellationToken);

                return mapper.Map<IEnumerable<GetStudentsQuery>>(result);
            });
        }
    }
}
