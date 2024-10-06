using CBTPreparation.APIs.Shared;

namespace CBTPreparation.APIs.Endpoints.FeedBack.GetFeedbacks
{
    public record GetFeedbacksResponse(
        string Comment,
        BaseApiResponse BaseResponse);

}
