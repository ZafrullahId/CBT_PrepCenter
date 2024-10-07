using Microsoft.AspNetCore.Mvc;

namespace CBTPreparation.APIs.Endpoints.FeedBack.GetFeedbacksId
{
    public record GetFeedbacksIdRequest([FromRoute(Name = "feedbackstudent-id")] Guid FeedbackStudentId);
}
