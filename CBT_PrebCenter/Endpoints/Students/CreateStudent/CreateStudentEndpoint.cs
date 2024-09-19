using Application.Abstractions;
using Application.Features.Students.CreateStudent;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CBT.APIs.Endpoints.Students.CreateStudent
{
    public class CreateStudentEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/students/", async (
                    [FromBody] CreateStudentRequest request,
                    IMapper mapper,
                    IMediator mediator,
                    CancellationToken cancellationToken) =>
            {
                var command = mapper.Map<CreateStudentCommand>(request);
                var response = await mediator.Send(command, cancellationToken);

                return mapper.Map<CreateStudentResponse>(response);
            }).WithTags(EndpointSchema.Student);
        }
    }
}
