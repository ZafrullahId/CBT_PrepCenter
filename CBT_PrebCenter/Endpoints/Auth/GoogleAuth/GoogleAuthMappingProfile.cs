using CBTPreparation.APIs.Endpoints.Feedback.CreateFeedback;
using CBTPreparation.Application.Features.Auth.GoogleAuth;
using CBTPreparation.Application.Features.Feedbacks.CreateFeedback;
using Mapster;

namespace CBTPreparation.APIs.Endpoints.Auth.GoogleAuth
{
    public class GoogleAuthMappingProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<GoogleAuthCommandResponse, GoogleAuthResponse>()
                .Map(x => x.BaseApiResponse, src => src.BaseResponse)
                .Map(x => x.Token, src => src.Token)
                .Map(x => x.RefreshToken, src => src.RefreshToken);

            config.ForType<CreateFeedbackCommandResponse, CreateFeedbackResponse>()
               .Map(x => x.Comment, src => src.Comment)
               .Map(x => x.FeedbackId, src => src.FeedbackId.Value)
               .Map(x => x.BaseApiResponse, src => src.BaseResponse);
        }
    }
}
