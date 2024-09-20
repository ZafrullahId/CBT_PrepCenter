using Application.Abstractions;
using Application.Features.FreeQuestions.CreateFreeQuestions;
using Application.Features.Students.CreateStudent;
using CBT.APIs.Endpoints.Students.CreateStudent;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CBT.APIs.Endpoints.FreeQuestion.CreateFreeQuestion
{
    public class CreateFreeQuestionEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/question/free/{subject}", async (
                    [FromBody] CreateFreeQuestionRequest request,
                    IMapper mapper,
                    IMediator mediator,
                    CancellationToken cancellationToken) =>
            {
                var command = mapper.Map<CreateFreeQuestionCommand>(request);
                var response = await mediator.Send(command, cancellationToken);

                return mapper.Map<CreateFreeQuestionResponse>(response);
            }).WithTags(EndpointSchema.Question);
        }
    }
}
