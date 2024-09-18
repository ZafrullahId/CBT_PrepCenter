using Application.Abstractions;
using Application.Features.Students.GetStudent;
using CBT.APIs.Endpoints;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CBT_PrepCenter.Endpoints.Students.GetStudent
{
    public class GetStudentEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/students/{student-id:guid}", async (
                    [AsParameters] GetStudentRequest request,
                    IMapper mapper,
                    IMediator mediator,
                    CancellationToken cancellationToken) =>
            {
                var command = mapper.Map<GetStudentQuery>(request);
                var response = await mediator.Send(command, cancellationToken);

                return mapper.Map<GetStudentResponse>(response);
            }).WithTags(EndpointSchema.Student);
        }
    }
}
