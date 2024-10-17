using CBTPreparation.APIs.Endpoints.Feedback.GetFeedbacks;
using CBTPreparation.APIs.Filters;
using CBTPreparation.Application.Features.Feedbacks.GetStudentFeedbacks;
using CBTPreparation_Application.Abstractions;
using MapsterMapper;
using MediatR;

namespace CBTPreparation.APIs.Endpoints.Feedback.GetStudentFeedback;

public partial class GetStudentFeedbackEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/feedbacks/student/{student-id:guid}", async (
               [AsParameters] GetStudentFeedbackRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
        {
            var command = mapper.Map<GetStudentFeedbackQuery>(request);
            var result = await mediator.Send(command, cancellationToken);

            return mapper.Map<GetFeedbacksResponse>(result);
        }).Validator<GetStudentFeedbackRequest>()
        .WithTags(EndpointSchema.Feedback);
    }
}
