using CBTPreparation.Application.Shared;
using CBTPreparation.Domain.FeedbackAggregate;

namespace CBTPreparation.Application.Features.Feedbacks.CreateFeedback
{
    public record CreateFeedbackCommandResponse(
       FeedbackId FeedbackId,
       string Comment,
       BaseResponse BaseResponse);
}
