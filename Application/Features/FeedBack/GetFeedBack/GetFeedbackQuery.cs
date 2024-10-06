using CBTPreparation.Domain.StudentAggregate;
using MediatR;

namespace CBTPreparation.Application.Features.FeedBack.GetFeedBack
{
    public record GetFeedbackQuery(FeedbackId FeedbackId) : IRequest<GetFeedbackQueryResponse>;
}
