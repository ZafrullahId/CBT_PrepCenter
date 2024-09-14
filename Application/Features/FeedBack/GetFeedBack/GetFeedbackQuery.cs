using MediatR;

namespace Application.Features.FeedBack.GetFeedBack
{
    public record GetFeedbackQuery(Guid FeedbackId) : IRequest<GetFeedbackQueryResponse>;
}
