using CBTPreparation.Application.Features.FreeQuestions.CreateFreeQuestions;
using Refit;

namespace CBTPreparation.Application.Abstractions.Service
{
    public interface IGetApiQuestionService
    {
        [Get("/m/40?subject={subject}")]
        Task<ApiResponse<CreateFreeQuestionCommand>> GetFreeQuestionsAsync(string subject);
    }
}
