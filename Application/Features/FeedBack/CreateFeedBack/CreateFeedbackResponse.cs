using Application.Shared;

namespace Application.Features.FeedBack.CreateFeedBack
{
    public record CreateFeedbackCommandResponse(
       Guid StudentId,
       string Comment,
       BaseResponse BaseResponse);
}
