using Blogger.BuildingBlocks.Domain;

namespace CBTPreparation.Domain.StudentAggregate
{
    public class Feedback : Entity<FeedbackId>
    {
        public string Comment { get; internal set; } = default!;
        public StudentId StudentId { get; internal set; }
        internal Feedback(FeedbackId feedbackId,
                          StudentId studentId,
                          string comment) : base(feedbackId)
        {
            Comment = comment;
            StudentId = studentId;
        }
        public static Feedback Create(string comment, StudentId studentId)
        {
            var feedBack = new Feedback(FeedbackId.CreateUniqueId(),
                                        studentId,
                                        comment);
            return feedBack;
        }
    }
}
