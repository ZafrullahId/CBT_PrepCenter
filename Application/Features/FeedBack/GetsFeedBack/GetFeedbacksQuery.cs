using MediatR;

namespace Application.Features.FeedBack.GetsFeedBack
{
    public record GetFeedbacksQuery : IRequest<List<GetFeedbacksQueryResponse>>;
}
