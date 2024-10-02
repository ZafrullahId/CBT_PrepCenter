using FluentValidation;

namespace CBTPreparation.APIs.Endpoints.Auth.GetRefreshToken
{
    public class GetTokenRequestValidator : AbstractValidator<GetTokenRequest>
    {
        public GetTokenRequestValidator()
        {
            RuleFor(p => p.Email).Cascade(CascadeMode.Stop)
                .NotEmpty()
                .EmailAddress()
                    .WithMessage("Invalid Email Address.");

            RuleFor(p => p.Password).Cascade(CascadeMode.Stop)
                .NotEmpty();
        }
    }
}
