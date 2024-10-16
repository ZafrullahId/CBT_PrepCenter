using CBTPreparation.APIs.Endpoints.FeedBack.GetFeedbacks;
using CBTPreparation.Application.Features.Feedbacks.GetStudentFeedbacks;
using Mapster;

namespace CBTPreparation.APIs.Endpoints.FeedBack.GetStudentFeedback
{
    public partial class GetStudentFeedbackEndpoint
    {
        public class GetStudentFeedbackMappingProfile : IRegister
        {
            public void Register(TypeAdapterConfig config)
            {
                config.ForType<GetStudentFeedbackRequest, GetStudentFeedbackQuery>()
                    .Map(x => x.StudentId.Value, src => src.StudentId);
                
                config.ForType<GetStudentFeedbackQueryResponse, GetFeedbacksResponse>()
                    .Map(x => x.Comment, src => src.Comment)
                    .Map(x => x.BaseApiResponse, src => src.BaseResponse);
            }
        }
    }
}
