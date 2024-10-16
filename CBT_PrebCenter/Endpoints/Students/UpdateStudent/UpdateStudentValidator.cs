using FluentValidation;

namespace CBTPreparation.APIs.Endpoints.Students.UpdateStudent
{
    public class UpdateStudentValidator : AbstractValidator<UpdateStudentRequestModel>
    {
        public UpdateStudentValidator()
        {
            RuleFor(x => x.StudentId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.body.Courses)
                .NotEmpty()
                .Must(x => x.Count == 4)
                .WithMessage("Choose 4 courses you are taking for JAMB");

            RuleFor(x => x.body.Department)
                .NotNull()
                .NotEmpty()
                .WithMessage("Choose a department");

            RuleFor(x => x.body.FirstName)
                .NotEmpty()
                .NotNull();
            
            RuleFor(x => x.body.LastName)
                .NotEmpty()
                .NotNull();

        }
    }
}
