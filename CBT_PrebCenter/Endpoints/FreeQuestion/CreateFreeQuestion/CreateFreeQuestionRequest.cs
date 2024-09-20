using Microsoft.AspNetCore.Mvc;

namespace CBT.APIs.Endpoints.FreeQuestion.CreateFreeQuestion
{
    public record class CreateFreeQuestionRequest([FromRoute(Name = "subject")] string Subject);
}
