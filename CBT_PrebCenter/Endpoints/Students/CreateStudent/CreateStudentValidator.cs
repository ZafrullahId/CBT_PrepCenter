using CBTPreparation.APIs.Endpoints.Students.CreateStudent;
using FluentValidation;

namespace CBT.APIs.Endpoints.Students.CreateStudent
{
    public class CreateStudentValidator : AbstractValidator<CreateStudentRequest>
    {
        public CreateStudentValidator() 
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("Please Input Your FirstName");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Please Input Your LastName");

            RuleFor(p => p.Email).Cascade(CascadeMode.Stop)
                .NotEmpty()
                .EmailAddress()
                    .WithMessage("Invalid Email Address.");

            RuleFor(p => p.Password)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull()
                .Length(8);
        }
    }
}
