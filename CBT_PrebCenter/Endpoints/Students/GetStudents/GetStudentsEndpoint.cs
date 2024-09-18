using Application.Abstractions;
using Application.Features.Students.GetStudents;
using CBT.APIs.Endpoints;
using MapsterMapper;
using MediatR;

namespace CBT_PrepCenter.Endpoints.Students.GetStudents
{
    public class GetStudentsEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/students/", async (
                    IMapper mapper,
                    IMediator mediator,
                    CancellationToken cancellationToken) =>
            {
                var command = new GetStudentsQuery();
                var result = await mediator.Send(command, cancellationToken);

                return mapper.Map<IEnumerable<GetStudentsQuery>>(result);
            }).WithTags(EndpointSchema.Student);
        }
    }
}
