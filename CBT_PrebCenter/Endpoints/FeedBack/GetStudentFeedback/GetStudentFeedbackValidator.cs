using FluentValidation;

namespace CBTPreparation.APIs.Endpoints.FeedBack.GetStudentFeedback
{
    public class GetStudentFeedbackValidator : AbstractValidator<GetStudentFeedbackRequest>
    {
        public GetStudentFeedbackValidator()
        {
            RuleFor(c => c.FeedbackStudentId)
                .NotEmpty()
                .NotNull();
        }
    }
}
