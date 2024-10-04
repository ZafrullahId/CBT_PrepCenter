using CBTPreparation.BuildingBlocks.Domain;
using CBTPreparation.Domain.Entity;
using CBTPreparation.Domain.TrialTransactionAggregate;
using CBTPreparation.Domain.UserAggregate;
namespace CBTPreparation.Domain.StudentAggregate;

public class Student : AggregateRoot<StudentId>
{
    public UserId UserId { get; private set; }
    private readonly List<Feedback> _feedbacks = new();
    private readonly List<Course> _courses = new();
    private readonly List<TrialTransaction> _trialTransactions = new();
    public int UnusedTrials { get; init; }
    public Department? Department { get; private set; }
    public IReadOnlyCollection<Course> Courses => _courses;
    public IReadOnlyCollection<Feedback> Feedbacks => _feedbacks;

    public IReadOnlyCollection<TrialTransaction> Transactions => _trialTransactions;

    private Student(StudentId studentId, UserId userId, int unusedTrials = 3) : base(studentId)
    {
        UserId = userId;
        UnusedTrials = unusedTrials;
    }
    public static Student Create(UserId userId)
    {
        var student = new Student(StudentId.CreateUniqueId(), userId);
        return student;
    }
    public void Update(string departmentName, IReadOnlyList<Course> courses)
    {
        ArgumentOutOfRangeException.ThrowIfZero(courses.Count);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(courses.Count, Constant.MaximumNumberOfCouse);
        Department = Department.Assign(departmentName);
        AddCourses(courses);

    }
    public void AddCourses(IReadOnlyCollection<Course> courses)
    {
        _courses.Clear();

        _courses.AddRange(courses);
    }
    public Feedback AddFeedBack(string comment)
    {
        var feedBack = Feedback.Create(Id,
                                    comment);
        _feedbacks.Add(feedBack);
        return feedBack;
    }
}
