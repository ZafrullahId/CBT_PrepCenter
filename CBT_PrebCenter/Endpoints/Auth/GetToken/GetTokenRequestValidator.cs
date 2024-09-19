using FluentValidation;
using Microsoft.Extensions.Localization;

namespace CBT.APIs.Endpoints.Auth.GetToken
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
