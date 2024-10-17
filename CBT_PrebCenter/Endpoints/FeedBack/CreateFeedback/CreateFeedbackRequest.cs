using CBTPreparation.Domain.StudentAggregate;
using Microsoft.AspNetCore.Mvc;

namespace CBTPreparation.APIs.Endpoints.Feedback.CreateFeedback
{
    public record CreateFeedbackRequest([FromRoute(Name = "student-id")] Guid StudentId, [FromBody] CreateCommentRequest body);
    public record CreateCommentRequest(string Comment);
}
