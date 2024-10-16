using CBTPreparation.APIs.Shared;

namespace CBTPreparation.APIs.Endpoints.FeedBack.GetFeedback
{
    public record GetFeedbackResponse(
        string Comment,
        BaseApiResponse BaseApiResponse);
}
