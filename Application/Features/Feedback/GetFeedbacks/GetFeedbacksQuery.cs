using MediatR;

namespace CBTPreparation.Application.Features.Feedback.GetFeedbacks
{
    public record GetFeedbacksQuery : IRequest<GetFeedbacksQueryResponse>;
}
