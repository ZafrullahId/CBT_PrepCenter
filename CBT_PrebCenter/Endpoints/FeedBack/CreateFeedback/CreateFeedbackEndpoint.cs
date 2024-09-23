using Application.Abstractions;
using Application.Features.FeedBack.CreateFeedBack;
using CBT.APIs.Filters;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CBT.APIs.Endpoints.FeedBack.CreateFeedback
{
    public class CreateFeedbackEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/feedback/", async (
                    [FromBody] CreateFeedbackRequest request,
                    IMapper mapper,
                    IMediator mediator,
                    CancellationToken cancellationToken) =>
            {
                var command = mapper.Map<CreateFeedbackCommand>(request);
                var response = await mediator.Send(command, cancellationToken);

                return mapper.Map<CreateFeedbackResponse>(response);
            }).Validator<CreateFeedbackRequest>()
            .WithTags(EndpointSchema.Feedback);
        }
    }
}
