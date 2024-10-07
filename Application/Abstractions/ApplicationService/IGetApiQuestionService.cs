using CBTPreparation.Application.Abstractions.ApplicationService.ExternalDto;
using CBTPreparation.Application.Features.FreeQuestions.CreateFreeQuestions;
using Refit;

namespace CBTPreparation.Application.Abstractions.Service
{
    public interface IGetApiQuestionService
    {
        [Get("/m/40?subject={subject}")]
        Task<ApiResponse<CreateFreeQuestionCommand>> GetFreeQuestionsAsync(string subject);
        // Fetch all available subjects
        [Get("/q-subjects")]
        Task<SubjectApiResponse> GetAllSubjects();

        // Fetch questions for specific subjects
        //[Get("/q-subjects-group")]
        [Get("/m/40?subject={subject}")]
        Task<SubjectResponse> GetQuestionsForSubjects(
            //[AliasAs("number")] int number,
            [AliasAs("subject")] string subject);
        //[AliasAs("subject2")] string subject2 = null,
        //[AliasAs("subject3")] string subject3 = null,
        //[AliasAs("subject4")] string subject4 = null);
    }
}
