using CBTPreparation.Application.Shared;

namespace CBTPreparation.Application.Features.Feedback.GetStudentFeedbacks
{
    public record GetStudentFeedbackQueryResponse(
    IEnumerable<string> Comment,
    BaseResponse BaseResponse);
}
