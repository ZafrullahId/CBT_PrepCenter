using FluentValidation;

namespace CBTPreparation.APIs.Endpoints.FeedBack.GetStudentFeedback
{
    public class GetStudentFeedbackValidator : AbstractValidator<GetStudentFeedbackRequest>
    {
        public GetStudentFeedbackValidator()
        {
            RuleFor(c => c.StudentId)
                .NotEmpty()
                .NotNull();
        }
    }
}
