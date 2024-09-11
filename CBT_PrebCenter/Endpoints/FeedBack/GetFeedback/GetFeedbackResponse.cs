using Application.Shared;

namespace CBT.APIs.Endpoints.FeedBack.GetFeedback
{
    public record GetFeedbackResponse(
        string Comment,
        BaseResponse BaseResponse);
}
