using FluentValidation;

namespace CBTPreparation.APIs.Endpoints.Feedback.CreateFeedback
{
    public class CreateFeedbackRequestValidator : AbstractValidator<CreateFeedbackRequest>
    {
        public CreateFeedbackRequestValidator()
        {
            RuleFor(p => p.StudentId)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.body.Comment).Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage("Invalid Input.");
        }
    }
}
