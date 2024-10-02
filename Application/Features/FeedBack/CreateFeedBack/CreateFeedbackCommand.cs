using MediatR;

namespace CBTPreparation.Application.Features.FeedBack.CreateFeedBack
{
    public record CreateFeedbackCommand(Guid StudentId,string Comment) : IRequest<CreateFeedbackCommandResponse>;
}
