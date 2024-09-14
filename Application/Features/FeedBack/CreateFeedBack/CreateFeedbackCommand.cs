using MediatR;

namespace Application.Features.FeedBack.CreateFeedBack
{
    public record CreateFeedbackCommand(Guid StudentId,string Comment) : IRequest<CreateFeedbackCommandResponse>;
}
