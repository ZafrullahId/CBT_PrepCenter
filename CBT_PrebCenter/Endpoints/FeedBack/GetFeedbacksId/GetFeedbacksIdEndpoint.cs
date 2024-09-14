using Application.Abstractions;
using Application.Features.FeedBack.GetFeedBacksId;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CBT.APIs.Endpoints.FeedBack.GetFeedbacksId
{
    public class GetFeedbacksIdEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/feedbacks/{feedback-id}", async (
                   [FromRoute] GetFeedbacksIdRequest request,
                    IMapper mapper,
                    IMediator mediator,
                    CancellationToken cancellationToken) =>
            {
                var command = mapper.Map<GetFeedbacksIdQuery>(request);
                var result = await mediator.Send(command, cancellationToken);

                return mapper.Map<IEnumerable<GetFeedbacksIdQuery>>(result);
            });
        }
    }
}
