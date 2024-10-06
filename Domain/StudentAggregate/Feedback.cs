using Blogger.BuildingBlocks.Domain;

namespace CBTPreparation.Domain.StudentAggregate
{
    public class Feedback : Entity<FeedbackId>
    {
        public StudentId StudentId { get; internal set; }
        public string Comment { get; internal set; } = default!;
        private Feedback(FeedbackId feedbackId) : base(feedbackId) { }
        private Feedback() : base(null!) { }
        //internal Feedback(FeedbackId feedbackId,
        //                  StudentId studentId,
        //                  string comment) : base(feedbackId)
        //{
        //    Comment = comment;
        //    StudentId = studentId;
        //}
        public static Feedback Create(StudentId studentId, string comment)
        {
            var feedBack = new Feedback(FeedbackId.CreateUniqueId())
            {
                StudentId = studentId,
                Comment = comment
            };

            return feedBack;
        }
    }
}
