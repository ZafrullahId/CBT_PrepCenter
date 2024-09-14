using Microsoft.AspNetCore.Mvc;

namespace CBT.APIs.Endpoints.FeedBack.GetFeedback
{
    public record GetFeedbackRequest([FromRoute(Name = "feedback-id")] string FeedbackId);
}
