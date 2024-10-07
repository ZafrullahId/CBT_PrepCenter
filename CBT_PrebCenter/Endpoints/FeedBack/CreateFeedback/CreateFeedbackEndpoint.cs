using CBTPreparation.APIs.Filters;
using CBTPreparation.Application.Features.FeedBack.CreateFeedBack;
using CBTPreparation_Application.Abstractions;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CBTPreparation.APIs.Endpoints.FeedBack.CreateFeedback
{
    public class CreateFeedbackEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/feedbacks/", async (
                    [FromBody] CreateFeedbackRequest request,
                    IMapper mapper,
                    IMediator mediator,
                    CancellationToken cancellationToken) =>
            {
                var command = mapper.Map<CreateFeedbackCommand>(request);
                var response = await mediator.Send(command, cancellationToken);

                return mapper.Map<CreateFeedbackResponse>(response);
            }).Validator<CreateFeedbackRequest>()
            .WithTags(EndpointSchema.Feedback);
        }
    }
}
