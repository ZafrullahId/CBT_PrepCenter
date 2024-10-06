using CBTPreparation_Application.Abstractions;
using CBTPreparation.APIs.Endpoints;
using MapsterMapper;
using MediatR;
using CBTPreparation.Application.Features.Students.GetStudents;

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
