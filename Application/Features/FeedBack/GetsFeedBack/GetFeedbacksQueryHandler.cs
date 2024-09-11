using Application.Abstractions.Repositories;
using MediatR;

namespace Application.Features.FeedBack.GetsFeedBack
{
    public class GetFeedbacksQueryHandler(IFeedbackRepository _feedbackRepository) : IRequestHandler<GetFeedbacksQuery, List<GetFeedbacksQueryResponse>>
    {
        public async Task<List<GetFeedbacksQueryResponse>> Handle(GetFeedbacksQuery request, CancellationToken cancellationToken)
        {
            var students = await _feedbackRepository.GetAllAsync(cancellationToken);

            return new List<GetFeedbacksQueryResponse>().ToList();
        }
    }
}
