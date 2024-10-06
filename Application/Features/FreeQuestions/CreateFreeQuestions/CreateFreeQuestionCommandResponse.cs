using CBTPreparation.Application.Shared;
using CBTPreparation.Domain.FreeQuestionAggregate;

namespace CBTPreparation.Application.Features.FreeQuestions.CreateFreeQuestions
{
    public record CreateFreeQuestionCommandResponse(List<CreateFreeQuestionDataCommandResponse> FreeQuestionDataCommandResponses, BaseResponse BaseResponse);
    public record CreateFreeQuestionDataCommandResponse(FreeQuestionId QuestionId,
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
