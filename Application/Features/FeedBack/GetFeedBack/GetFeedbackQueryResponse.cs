using CBTPreparation.Application.Shared;

namespace CBTPreparation.Application.Features.Feedback.GetFeedback
{
    public record GetFeedbackQueryResponse(
        string Comment,
        BaseResponse BaseResponse);
}
