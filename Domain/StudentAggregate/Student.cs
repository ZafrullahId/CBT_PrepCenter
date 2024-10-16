using CBTPreparation.BuildingBlocks.Domain;
using CBTPreparation.Domain.CourseAggregate;
using CBTPreparation.Domain.Entity;
using CBTPreparation.Domain.FeedbackAggregate;
using CBTPreparation.Domain.TrialTransactionAggregate;
using CBTPreparation.Domain.UserAggregate;

namespace CBTPreparation.Domain.StudentAggregate;

public class Student : AggregateRoot<StudentId>
{
    public UserId UserId { get; private set; }
    public int UnusedTrials { get; private set; }
    public Department? Department { get; private set; }

    private readonly List<CourseId> _coursesIds = null!;
    public IReadOnlyCollection<CourseId> CoursesIds => [.. _coursesIds];

    private readonly List<FeedbackId> _feedbackIds = null!;
    public IReadOnlyCollection<FeedbackId> FeedbackIds => [.. _feedbackIds];

    private readonly List<TrialTransactionId> _trialTransactionIds = null!;
    public IReadOnlyCollection<TrialTransactionId> TrialTransactionIds => [.. _trialTransactionIds];

    private Student(StudentId studentId) : base(studentId)
    {
        _trialTransactionIds = [];
        _feedbackIds = [];
        _coursesIds = [];
    }
    private Student() : base(null!) { }
    public static Student Create(UserId userId)
    {
        var student = new Student(StudentId.CreateUniqueId())
        {
            UserId = userId
        };
        return student;
    }
    public void Update(string departmentName, IReadOnlyList<CourseId> courses)
    {
        ArgumentOutOfRangeException.ThrowIfZero(courses.Count);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(courses.Count, Constant.MaximumNumberOfCouse);
        Department = Department.Assign(departmentName);
        UpdateCourses(courses);

    }
    public void UpdateCourses(IReadOnlyCollection<CourseId> courses)
    {
        // check if course exist in the command Handler

        _coursesIds.Clear();

        _coursesIds.AddRange(courses);

    }
}
