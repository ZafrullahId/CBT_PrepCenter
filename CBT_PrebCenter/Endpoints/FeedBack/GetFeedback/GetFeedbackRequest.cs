using Microsoft.AspNetCore.Mvc;

namespace CBTPreparation.APIs.Endpoints.FeedBack.GetFeedback
{
    public record GetFeedbackRequest([FromRoute(Name = "feedback-id")] Guid FeedbackId);
}
