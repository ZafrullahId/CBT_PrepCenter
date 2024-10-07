using Microsoft.AspNetCore.Mvc;

namespace CBTPreparation.APIs.Endpoints.FeedBack.GetStudentFeedback
{
    public record GetStudentFeedbackRequest([FromRoute(Name = "student-id")] Guid FeedbackStudentId);
}
