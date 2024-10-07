using CBTPreparation.Domain.StudentAggregate;
using MediatR;


namespace CBTPreparation.Application.Features.Feedback.GetStudentFeedbacks
{
    public record GetStudentFeedbackQuery(StudentId StudentId) : IRequest<GetStudentFeedbackQueryResponse>;
}
