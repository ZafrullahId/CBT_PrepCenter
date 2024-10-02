using MediatR;

namespace CBTPreparation.Application.Features.FeedBack.GetFeedBack
{
    public record GetFeedbackQuery(Guid FeedbackId) : IRequest<GetFeedbackQueryResponse>;
}
