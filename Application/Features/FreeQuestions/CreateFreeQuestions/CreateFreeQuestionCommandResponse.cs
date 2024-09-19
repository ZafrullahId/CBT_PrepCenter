using Application.Shared;

namespace Application.Features.FreeQuestions.CreateFreeQuestions
{
    public record CreateFreeQuestionCommandResponse(List<CreateFreeQuestionDataCommandResponse> FreeQuestionDataCommandResponses, BaseResponse BaseResponse);
    public record CreateFreeQuestionDataCommandResponse(Guid QuestionId,
                                                        string SubjectName,
                                                        string QuestionContent,
                                                        string ExamType,
                                                        string ExamYear,
                                                        string? ImageUrl,
                                                        List<CreateFreeQuestionDataOptionCommandResponse> OptionCommandResponses);
    public record CreateFreeQuestionDataOptionCommandResponse(string OptionContent,
                                                              char OptionAlpha,
                                                              string? imageUrl = null);
}
