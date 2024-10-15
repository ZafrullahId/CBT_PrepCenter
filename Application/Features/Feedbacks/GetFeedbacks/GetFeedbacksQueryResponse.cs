using CBTPreparation.Application.Shared;

namespace CBTPreparation.Application.Features.Feedbacks.GetFeedbacks
{
    public record GetFeedbacksQueryResponse(
    IEnumerable<string> Comment,
    BaseResponse BaseResponse);
}
