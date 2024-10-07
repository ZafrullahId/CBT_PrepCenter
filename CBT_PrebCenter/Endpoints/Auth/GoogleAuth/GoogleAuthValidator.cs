using FluentValidation;

namespace CBTPreparation.APIs.Endpoints.Auth.GoogleAuth
{
    public class GoogleAuthValidator : AbstractValidator<GoogleAuthRequest>
    {
        public GoogleAuthValidator()
        {
            RuleFor(x => x.TokenId)
                .NotEmpty()
                .NotNull();
        }
    }
}
