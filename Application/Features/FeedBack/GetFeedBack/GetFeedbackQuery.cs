using CBTPreparation.Domain.StudentAggregate;
using MediatR;

namespace CBTPreparation.Application.Features.Feedback.GetFeedback
{
    public record GetFeedbackQuery(FeedbackId FeedbackId) : IRequest<GetFeedbackQueryResponse>;
}
