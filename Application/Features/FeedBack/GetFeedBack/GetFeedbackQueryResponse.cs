using Application.Shared;

namespace Application.Features.FeedBack.GetFeedBack
{
    public record GetFeedbackQueryResponse(
        string Comment,
        BaseResponse BaseResponse);
}
