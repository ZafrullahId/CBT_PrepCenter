using Microsoft.AspNetCore.Mvc;

namespace CBTPreparation.APIs.Endpoints.FreeQuestion.CreateFreeQuestion
{
    public record class CreateFreeQuestionRequest([FromRoute(Name = "subject")] string Subject);
}
