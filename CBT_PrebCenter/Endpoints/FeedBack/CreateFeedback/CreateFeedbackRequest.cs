namespace CBT.APIs.Endpoints.FeedBack.CreateFeedback
{
    public record CreateFeedbackRequest(Guid StudentId, string Comment);
}
