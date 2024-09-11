using Application.Abstractions.Repositories;
using Application.Exceptions;
using Application.Shared;
using MediatR;

namespace Application.Features.FeedBack.GetFeedBack
{
    public class GetFeedbackQueryHandler(IFeedbackRepository _feedbackRepository) : IRequestHandler<GetFeedbackQuery, GetFeedbackQueryResponse>
    {
        public async Task<GetFeedbackQueryResponse> Handle(GetFeedbackQuery request, CancellationToken cancellationToken)
        {
            var feedId = await _feedbackRepository.GetAsync(request.FeedbackId, cancellationToken);

            if (feedId == null) { throw new NotFoundException(feedId.Id.ToString()); }

            return new GetFeedbackQueryResponse(
               feedId.Comment,
                new BaseResponse(
                "Comment Retrived Successfully",
                true));
        }
    }
}
