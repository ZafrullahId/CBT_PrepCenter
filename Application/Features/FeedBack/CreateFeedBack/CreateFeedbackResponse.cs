using CBTPreparation.Application.Shared;

namespace CBTPreparation.Application.Features.FeedBack.CreateFeedBack
{
    public record CreateFeedbackCommandResponse(
       Guid StudentId,
       string Comment,
       BaseResponse BaseResponse);
}
