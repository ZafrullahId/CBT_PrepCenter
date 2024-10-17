using Microsoft.AspNetCore.Mvc;

namespace CBTPreparation.APIs.Endpoints.Feedback.GetFeedback
{
    public record GetFeedbackRequest([FromRoute(Name = "feedback-id")] Guid FeedbackId);
}
