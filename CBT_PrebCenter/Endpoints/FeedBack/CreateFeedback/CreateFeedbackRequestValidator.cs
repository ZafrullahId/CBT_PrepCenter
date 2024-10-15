using CBTPreparation.APIs.Endpoints.FeedBack.CreateFeedback;
using FluentValidation;

namespace CBT.APIs.Endpoints.FeedBack.CreateFeedback
{
    public class CreateFeedbackRequestValidator  : AbstractValidator<CreateFeedbackRequest>
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
