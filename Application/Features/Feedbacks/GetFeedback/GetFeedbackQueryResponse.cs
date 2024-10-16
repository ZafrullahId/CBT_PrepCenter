using CBTPreparation.Application.Shared;

namespace CBTPreparation.Application.Features.Feedbacks.GetFeedback
{
    public record GetFeedbackQueryResponse(
        string Comment,
        BaseResponse BaseResponse);
}
