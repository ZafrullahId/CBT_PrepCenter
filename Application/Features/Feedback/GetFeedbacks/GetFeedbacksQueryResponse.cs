using CBTPreparation.Application.Shared;

namespace CBTPreparation.Application.Features.Feedback.GetFeedbacks
{
    public record GetFeedbacksQueryResponse(
    IEnumerable<string> Comment,
    BaseResponse BaseResponse);
}
