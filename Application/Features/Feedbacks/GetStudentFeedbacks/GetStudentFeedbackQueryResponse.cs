using CBTPreparation.Application.Shared;

namespace CBTPreparation.Application.Features.Feedbacks.GetStudentFeedbacks
{
    public record GetStudentFeedbackQueryResponse(
    IEnumerable<string> Comment,
    BaseResponse BaseResponse);
}
