using Domain.Exceptions;

namespace Application.Features.Students.GetStudent
{
    public class NotFoundStudentException : DomainException
    {
        private const string _message = "Student not found.";

        public NotFoundStudentException() : base(_message)
        {

        }
    }
}
