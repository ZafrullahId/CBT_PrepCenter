using CBTPreparation.Application.Features.FreeQuestions.CreateFreeQuestions;
using CBTPreparation_Application.Abstractions;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CBTPreparation.APIs.Endpoints.FreeQuestion.CreateFreeQuestion
{
    public class CreateFreeQuestionEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/question/free/{subject}", async (
                    [AsParameters] CreateFreeQuestionRequest request,
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
