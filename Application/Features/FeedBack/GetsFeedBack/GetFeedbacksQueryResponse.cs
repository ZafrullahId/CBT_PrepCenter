using CBTPreparation.Application.Shared;

namespace CBTPreparation.Application.Features.FeedBack.GetsFeedBack
{
    public record GetFeedbacksQueryResponse(
    string Comment,
    BaseResponse BaseResponse); 
}
