using CBTPreparation.APIs.Filters;
using CBTPreparation.Application.Features.Feedbacks.GetFeedback;
using CBTPreparation_Application.Abstractions;
using MapsterMapper;
using MediatR;

namespace CBTPreparation.APIs.Endpoints.Feedback.GetFeedback
{
    public class GetFeedbackEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/feedbacks/{feedback-id:guid}", async (
                    [AsParameters] GetFeedbackRequest request,
                    IMapper mapper,
                    IMediator mediator,
                    CancellationToken cancellationToken) =>
            {
                var command = mapper.Map<GetFeedbackQuery>(request);
                var response = await mediator.Send(command, cancellationToken);

                return mapper.Map<GetFeedbackResponse>(response);
            }).Validator<GetFeedbackRequest>()
            .WithTags(EndpointSchema.Feedback);
        }
    }
}
