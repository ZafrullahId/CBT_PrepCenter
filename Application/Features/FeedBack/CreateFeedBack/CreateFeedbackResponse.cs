using CBTPreparation.Application.Shared;
using CBTPreparation.Domain.StudentAggregate;

namespace CBTPreparation.Application.Features.Feedback.CreateFeedback
{
    public record CreateFeedbackCommandResponse(
       FeedbackId FeedbackId,
       string Comment,
       BaseResponse BaseResponse);
}
