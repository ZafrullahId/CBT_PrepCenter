using CBTPreparation.Application.Features.Feedbacks.GetFeedback;
using Mapster;

namespace CBTPreparation.APIs.Endpoints.Feedback.GetFeedback
{
    public class GetFeedbackMappingProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<GetFeedbackRequest, GetFeedbackQuery>()
                .Map(x => x.FeedbackId.Value, src => src.FeedbackId);

            config.ForType<GetFeedbackQueryResponse, GetFeedbackResponse>()
                    .Map(x => x.Comment, src => src.Comment)
                    .Map(x => x.BaseApiResponse, src => src.BaseResponse);
        }
    }
}
