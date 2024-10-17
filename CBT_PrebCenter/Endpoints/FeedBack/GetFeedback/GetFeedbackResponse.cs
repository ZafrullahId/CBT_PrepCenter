using CBTPreparation.APIs.Shared;

namespace CBTPreparation.APIs.Endpoints.Feedback.GetFeedback
{
    public record GetFeedbackResponse(
        string Comment,
        BaseApiResponse BaseApiResponse);
}
