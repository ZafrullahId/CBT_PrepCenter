using CBTPreparation.Domain.StudentAggregate;
using MediatR;


namespace CBTPreparation.Application.Features.Feedbacks.GetStudentFeedbacks
{
    public record GetStudentFeedbackQuery(StudentId StudentId) : IRequest<GetStudentFeedbackQueryResponse>;
}
