using CBTPreparation.Application.Features.Feedbacks.GetFeedbacks;
using CBTPreparation_Application.Abstractions;
using Mapster;
using MapsterMapper;
using MediatR;

namespace CBTPreparation.APIs.Endpoints.FeedBack.GetFeedbacks
{
    public class GetFeedbacksEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/feedbacks/", async (
                    [AsParameters] GetFeedbacksRequest request,
                    IMapper mapper,
                    IMediator mediator,
                    CancellationToken cancellationToken) =>
            {
                var command = mapper.Map<GetFeedbacksQuery>(request);
                var result = await mediator.Send(command, cancellationToken);

                return mapper.Map<GetFeedbacksResponse>(result);
            }).WithTags(EndpointSchema.Feedback);
        }
    }
    public class GetFeedbackMappingProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<GetFeedbacksRequest, GetFeedbacksQuery>()
                .Map(x => x, src => src);

            config.ForType<GetFeedbacksQueryResponse, GetFeedbacksResponse>()
                .Map(x => x.Comment, src => src.Comment)
                .Map(x => x.BaseApiResponse, src => src.BaseResponse);
        }
    }
}
