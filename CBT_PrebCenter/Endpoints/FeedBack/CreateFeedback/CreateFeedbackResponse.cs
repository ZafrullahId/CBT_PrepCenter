using CBTPreparation.APIs.Shared;
using CBTPreparation.Domain.FeedbackAggregate;

namespace CBTPreparation.APIs.Endpoints.Feedback.CreateFeedback
{
    public record CreateFeedbackResponse(Guid FeedbackId, string Comment, BaseApiResponse BaseApiResponse);
}
