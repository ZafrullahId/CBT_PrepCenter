using CBTPreparation_Application.Abstractions;
using CBTPreparation.APIs.Endpoints;
using MapsterMapper;
using MediatR;
using CBTPreparation.Application.Features.Students.GetStudent;
using Microsoft.AspNetCore.Mvc;

namespace CBT_PrepCenter.Endpoints.Students.GetStudent
{
    public class GetStudentEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/students/{student-id:guid}", async (
                    [AsParameters] GetStudentRequest request,
                    [FromServices] IMapper mapper,
                    [FromServices] IMediator mediator,
                    CancellationToken cancellationToken) =>
            {
                var command = mapper.Map<GetStudentQuery>(request);
                var response = await mediator.Send(command, cancellationToken);

                return mapper.Map<GetStudentResponse>(response);
            }).WithTags(EndpointSchema.Student);
        }
    }
}
