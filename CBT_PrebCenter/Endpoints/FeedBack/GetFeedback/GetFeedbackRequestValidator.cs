using FluentValidation;

namespace CBTPreparation.APIs.Endpoints.FeedBack.GetFeedback
{
    public class GetFeedbackRequestValidator : AbstractValidator<GetFeedbackRequest>
    {
        public GetFeedbackRequestValidator()
        {
            RuleFor(p => p.FeedbackId)
                .NotEmpty()
                .NotNull();

        }
    }
}
