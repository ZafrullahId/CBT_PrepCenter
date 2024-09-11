using Application.Shared;

namespace Application.Features.FeedBack.GetsFeedBack
{
    public record GetFeedbacksQueryResponse(
    string Comment,
    BaseResponse BaseResponse); 
}
