using CBTPreparation.Domain.StudentAggregate;
using MediatR;

namespace CBTPreparation.Application.Features.FeedBack.CreateFeedBack
{
    public record CreateFeedbackCommand(StudentId StudentId, string Comment) : IRequest<CreateFeedbackCommandResponse>;
}
