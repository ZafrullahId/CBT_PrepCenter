using CBTPreparation.APIs.Filters;
using CBTPreparation.Application.Features.Students.UpdateStudent;
using CBTPreparation_Application.Abstractions;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CBTPreparation.APIs.Endpoints.Students.UpdateStudent
{
    public class UpdateStudentEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPut("/students/{student-id:guid}", async (
                    [AsParameters] UpdateStudentRequestModel request,
                    IMapper mapper,
                    IMediator mediator,
                    CancellationToken cancellationToken) =>
            {
                var command = mapper.Map<UpdateStudentCommand>(request);
                var response = await mediator.Send(command, cancellationToken);

                return mapper.Map<UpdateStudentResponse>(response);
            }).Validator<UpdateStudentRequest>()
            .WithTags(EndpointSchema.Student);
        }
    }
}
