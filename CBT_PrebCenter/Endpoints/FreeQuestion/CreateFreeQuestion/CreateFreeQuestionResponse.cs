using Application.Shared;

namespace CBT.APIs.Endpoints.FreeQuestion.CreateFreeQuestion
{
    public record CreateFreeQuestionResponse(List<CreateFreeQuestionDataResponse> FreeQuestionDataCommandResponses, BaseResponse BaseResponse);
    public record CreateFreeQuestionDataResponse(Guid QuestionId,
                                                        string SubjectName,
                                                        string QuestionContent,
                                                        string ExamType,
                                                        string ExamYear,
                                                        string? ImageUrl,
                                                        List<CreateFreeQuestionDataOptionResponse> OptionCommandResponses);
    public record CreateFreeQuestionDataOptionResponse(string OptionContent,
                                                              char OptionAlpha,
                                                              string? imageUrl = null);
}
