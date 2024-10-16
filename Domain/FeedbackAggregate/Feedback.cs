using CBTPreparation.BuildingBlocks.Domain;
using CBTPreparation.Domain.StudentAggregate;

namespace CBTPreparation.Domain.FeedbackAggregate
{
    public class Feedback : AggregateRoot<FeedbackId>
    {
        public StudentId StudentId { get; internal set; }
        public string Comment { get; internal set; } = default!;
        private Feedback(FeedbackId feedbackId) : base(feedbackId) { }
        private Feedback() : base(null!) { }
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
