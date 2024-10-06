using CBTPreparation.Application.Shared;
using CBTPreparation.Domain.StudentAggregate;

namespace CBTPreparation.Application.Features.FeedBack.CreateFeedBack
{
    public record CreateFeedbackCommandResponse(
       FeedbackId FeedbackId,
       string Comment,
       BaseResponse BaseResponse);
}
