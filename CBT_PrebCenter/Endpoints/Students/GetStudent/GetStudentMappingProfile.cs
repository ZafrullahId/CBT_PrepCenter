using CBT_PrepCenter.Endpoints.Students.GetStudent;
using CBTPreparation.Application.Features.Students.GetStudent;
using CBTPreparation.Domain.StudentAggregate;
using Mapster;

namespace CBTPreparation.APIs.Endpoints.Students.GetStudent
{
    public class GetStudentMappingProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<GetStudentRequest, GetStudentQuery>()
                       .Map(x => x.StudentId, src => StudentId.Create(src.StudentId));
        }
    }
}
