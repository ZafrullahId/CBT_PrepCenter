using CBTPreparation.APIs.Shared;

namespace CBTPreparation.APIs.Endpoints.FeedBack.GetFeedbacks
{
    public record GetFeedbacksResponse(
        IEnumerable<string> Comment,
    BaseApiResponse BaseApiResponse);

}
