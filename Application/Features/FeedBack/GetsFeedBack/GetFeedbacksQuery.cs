using MediatR;

namespace CBTPreparation.Application.Features.FeedBack.GetsFeedBack
{
    public record GetFeedbacksQuery : IRequest<List<GetFeedbacksQueryResponse>>;
}
