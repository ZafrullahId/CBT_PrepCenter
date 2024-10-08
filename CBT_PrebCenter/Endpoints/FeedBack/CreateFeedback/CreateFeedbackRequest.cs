using CBTPreparation.Domain.StudentAggregate;
using Microsoft.AspNetCore.Mvc;

namespace CBTPreparation.APIs.Endpoints.FeedBack.CreateFeedback
{
    public record CreateFeedbackRequest([FromRoute(Name = "student-id")]  Guid StudentId, [FromBody] CreateCommentRequest body);
    public record CreateCommentRequest(string Comment);
}
