using CBTPreparation.APIs.Shared;

namespace CBT_PrepCenter.Endpoints.Students.GetStudents
{
    public record GetStudentsResponse(
        string FirstName,
        string LastName,
        string Email,
        string Department,
        IEnumerable<string> Courses,
        BaseApiResponse BaseResponse);
    public record GetStudentsQueryResponse(List<GetStudentsResponse> Students,
                                           BaseApiResponse BaseResponse);
}
