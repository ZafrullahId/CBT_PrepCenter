using CBTPreparation.APIs.Filters;
using CBTPreparation.Application.Features.Feedbacks.CreateFeedback;
using CBTPreparation_Application.Abstractions;
using MapsterMapper;
using MediatR;

namespace CBTPreparation.APIs.Endpoints.Feedback.CreateFeedback
{
    public class CreateFeedbackEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/feedbacks/{student-id:guid}", async (
                    [AsParameters] CreateFeedbackRequest request,
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
