using Microsoft.AspNetCore.Mvc;

namespace CBT.APIs.Endpoints.FeedBack.GetFeedbacksId
{
    public record GetFeedbacksIdRequest([FromRoute(Name = "student-id")] string StudentId);
}
