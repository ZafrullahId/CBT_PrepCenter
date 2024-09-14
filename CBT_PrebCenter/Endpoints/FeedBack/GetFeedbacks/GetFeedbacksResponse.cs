using Application.Shared;

namespace CBT.APIs.Endpoints.FeedBack.GetFeedbacks
{
    public record GetFeedbacksResponse(
        string Comment,
        BaseResponse BaseResponse);

}
