using Application.Features.FreeQuestions.CreateFreeQuestions;
using Refit;

namespace Application.Abstractions.Service
{
    public interface IGetApiQuestionService
    {
        [Get("/m/40?subject={subject}")]
        Task<ApiResponse<CreateFreeQuestionCommand>> GetFreeQuestionsAsync(string subject);

        [Get("/q-subjects-group?number=40&subject1=chemistry&subject2=physics&subject3=mathematics&subject4=english")]
        Task<IEnumerable<ExternalQuestion>> GetQuestionsAsync();

    }
}
