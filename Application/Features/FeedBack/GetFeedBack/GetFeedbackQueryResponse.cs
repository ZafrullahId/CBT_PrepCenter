using CBTPreparation.Application.Shared;

namespace CBTPreparation.Application.Features.FeedBack.GetFeedBack
{
    public record GetFeedbackQueryResponse(
        string Comment,
        BaseResponse BaseResponse);
}
