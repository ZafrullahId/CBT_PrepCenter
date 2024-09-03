using Application.Shared;

namespace Application.Features.Students.Dtos.Response
{
    public class StudentResponse : BaseResponse
    {
        public StudentDto? Data { get; set; }
    }

    public class StudentsResponse : BaseResponse
    {
        public List<StudentDto>? Data { get; set; }

    }
}
