using CBTPreparation.APIs.Shared;
using CBTPreparation.Domain.FeedbackAggregate;

namespace CBTPreparation.APIs.Endpoints.FeedBack.CreateFeedback
{
    public record CreateFeedbackResponse(Guid FeedbackId, string Comment, BaseApiResponse BaseApiResponse);
}
