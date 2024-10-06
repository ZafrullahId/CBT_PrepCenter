using CBTPreparation.Domain.StudentAggregate;

namespace CBTPreparation.Domain
{
    public record StudentWithUserDto
    (StudentId StudentId,
     string FirstName,
     string LastName,
     string Email,
     string Department,
     List<string> Courses);
}
