using CBTPreparation.Domain.StudentAggregate;
using MediatR;

namespace CBTPreparation.Application.Features.Feedback.CreateFeedback
{
    public record CreateFeedbackCommand(StudentId StudentId, string Comment) : IRequest<CreateFeedbackCommandResponse>;
}
