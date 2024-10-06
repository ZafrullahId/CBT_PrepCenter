namespace CBTPreparation.Domain.StudentAggregate
{
    public interface IStudentRepository
    {
        Task CreateStudentAsync(Student student, CancellationToken cancellationToken);
        Task<Student?> GetStudentAsync(StudentId studentId, CancellationToken cancellationToken);
        Task<List<StudentWithUserDto>> GetAllStudentAsync(CancellationToken cancellationToken);
        Task<IReadOnlyList<Feedback>> GetAllFeedbacksAsync(CancellationToken cancellationToken);
        Task<Feedback?> GetFeedbackByIdAsync(FeedbackId feedbackId, CancellationToken cancellationToken);
        Task<IReadOnlyList<Feedback>> GetAllFeedbackByStudentIdAsync(StudentId studentId, CancellationToken cancellationToken);
    }
}
