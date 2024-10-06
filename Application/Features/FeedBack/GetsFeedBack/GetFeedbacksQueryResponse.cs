using CBTPreparation.Application.Shared;

namespace CBTPreparation.Application.Features.FeedBack.GetsFeedBack
{
    public record GetFeedbacksQueryResponse(
    IEnumerable<string> Comment,
    BaseResponse BaseResponse); 
}
