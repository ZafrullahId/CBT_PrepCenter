using CBTPreparation.Application.Features.FeedBack.GetsFeedBack;
using CBTPreparation_Application.Abstractions;
using MapsterMapper;
using MediatR;

namespace CBTPreparation.APIs.Endpoints.FeedBack.GetFeedbacks
{
    public class GetFeedbacksEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/feedbacks/", async (
                     GetFeedbacksRequest request,
                    IMapper mapper,
                    IMediator mediator,
                    CancellationToken cancellationToken) =>
            {
                var command = mapper.Map<GetFeedbacksQuery>(request);
                var result = await mediator.Send(command, cancellationToken);

                return mapper.Map<IEnumerable<GetFeedbacksQuery>>(result);
            });
        }
    }
}
