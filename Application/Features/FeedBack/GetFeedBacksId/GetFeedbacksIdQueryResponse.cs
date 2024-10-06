using CBTPreparation.Application.Shared;

namespace CBTPreparation.Application.Features.FeedBack.GetFeedBacksId
{
    public record GetFeedbacksIdQueryResponse(
    IEnumerable<string> Comment,
    BaseResponse BaseResponse);
}
