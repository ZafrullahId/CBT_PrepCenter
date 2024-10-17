using Microsoft.AspNetCore.Mvc;

namespace CBTPreparation.APIs.Endpoints.Feedback.GetStudentFeedback
{
    public record GetStudentFeedbackRequest([FromRoute(Name = "student-id")] Guid StudentId);
}
