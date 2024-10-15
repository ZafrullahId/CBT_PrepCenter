using CBTPreparation.Domain.FeedbackAggregate;
using MediatR;

namespace CBTPreparation.Application.Features.Feedbacks.GetFeedback
{
    public record GetFeedbackQuery(FeedbackId FeedbackId) : IRequest<GetFeedbackQueryResponse>;
}
