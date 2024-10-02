﻿using CBTPreparation.Application.Features.FeedBack.GetFeedBack;
using CBTPreparation_Application.Abstractions;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CBTPreparation.APIs.Endpoints.FeedBack.GetFeedback
{
    public class GetFeedbackEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/feedback/{feedback-id}", async (
                    [FromRoute] GetFeedbackRequest request,
                    IMapper mapper,
                    IMediator mediator,
                    CancellationToken cancellationToken) =>
            {
                var command = mapper.Map<GetFeedbackQuery>(request);
                var response = await mediator.Send(command, cancellationToken);

                return mapper.Map<GetFeedbackResponse>(response);
            });
        }
    }
}
