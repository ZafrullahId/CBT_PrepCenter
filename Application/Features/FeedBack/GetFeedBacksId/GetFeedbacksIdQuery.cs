using MediatR;


namespace Application.Features.FeedBack.GetFeedBacksId
{
    public record GetFeedbacksIdQuery(Guid StudentId) : IRequest<List<GetFeedbacksIdQueryResponse>>;
}
