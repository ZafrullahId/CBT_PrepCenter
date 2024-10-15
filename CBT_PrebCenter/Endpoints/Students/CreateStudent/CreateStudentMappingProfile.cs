using CBTPreparation.Application.Features.Students.CreateStudent;
using CBTPreparation.Domain.CourseAggregate;
using Mapster;

namespace CBTPreparation.APIs.Endpoints.Students.CreateStudent
{
    public class CreateStudentMappingProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {

            config.ForType<CreateStudentCommandResponse, CreateStudentResponse>()
                .Map(x => x.StudentId, src => src.StudentId.Value);

            config.ForType<CreateStudentRequest, CreateStudentCommand>()
                .Map(x => x.FirstName, src => src.FirstName)
                .Map(x => x.LastName, src => src.LastName)
                .Map(x => x.Email, src => src.Email)
                .Map(x => x.Password, src => src.Password)
                .Map(x => x.Department, src => src.Department)
                .Map(x => x.Courses, src => src.Courses.Select(courseGuid => new CourseId { Value = courseGuid }).ToList());
        }
    }
}
