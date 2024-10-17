using CBTPreparation.APIs.Shared;

namespace CBTPreparation.APIs.Endpoints.Feedback.GetFeedbacks
{
    public record GetFeedbacksResponse(
        IEnumerable<string> Comment,
    BaseApiResponse BaseApiResponse);

}
