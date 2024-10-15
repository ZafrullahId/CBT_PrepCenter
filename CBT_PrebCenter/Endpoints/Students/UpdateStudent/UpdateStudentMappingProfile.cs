using CBTPreparation.Application.Features.Students.UpdateStudent;
using CBTPreparation.Domain.CourseAggregate;
using CBTPreparation.Domain.StudentAggregate;
using Mapster;

namespace CBTPreparation.APIs.Endpoints.Students.UpdateStudent
{
    public class UpdateStudentMappingProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<UpdateStudentRequestModel, UpdateStudentCommand>()
                       .Map(x => x.StudentId, src => StudentId.Create(src.StudentId))
                       .Map(x => x.FirstName, src => src.body.FirstName)
                       .Map(x => x.LastName, src => src.body.LastName)
                       .Map(x => x.Department, src => src.body.Department)
                       .Map(x => x.Courses, src => src.body.Courses.Select(courseGuid => new CourseId { Value = courseGuid }).ToList());  
            
            config.ForType<UpdateStudentCommandResponse, UpdateStudentResponse>()
                       .Map(x => x.BaseApiResponse, src => src.BaseResponse);
        }
    }
}
