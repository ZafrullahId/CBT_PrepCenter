using CBTPreparation.Application.Features.Students.CreateStudent;
using CBTPreparation_Application.Abstractions;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CBTPreparation.APIs.Endpoints.Students.CreateStudent
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
            }).Validator< CreateStudentRequest>()
            .WithTags(EndpointSchema.Student);
        }
    }
}
