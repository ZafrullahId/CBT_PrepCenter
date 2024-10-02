using Blogger.BuildingBlocks.Domain;
using CBTPreparation.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Student : Entity<StudentId>
    {
        private readonly List<Feedback> _feedbacks = new();
        private readonly List<Course> _courses = new();
        public int UnusedTrials { get; init; }
        public Department? Department { get; private set; }
        public IReadOnlyCollection<Course> Courses => _courses;
        public IReadOnlyCollection<Feedback> Feedbacks => _feedbacks;

        private Student(StudentId studentId, int unusedTrials = 3) : base(studentId)
        {
            UnusedTrials = unusedTrials;
        }
        public static Student Create()
        {
            var student = new Student(StudentId.CreateUniqueId());
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
            var feedBack = new Feedback(FeedbackId.CreateUniqueId(),
                                        Id,
                                        comment);
            _feedbacks.Add(feedBack);
            return feedBack;
        }
    }
}
