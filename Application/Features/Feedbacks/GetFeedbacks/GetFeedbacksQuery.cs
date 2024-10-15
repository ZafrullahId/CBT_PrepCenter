using MediatR;

namespace CBTPreparation.Application.Features.Feedbacks.GetFeedbacks
{
    public record GetFeedbacksQuery() : IRequest<GetFeedbacksQueryResponse>;
}
