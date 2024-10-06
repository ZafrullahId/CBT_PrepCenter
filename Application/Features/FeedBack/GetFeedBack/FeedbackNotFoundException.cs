using System.Net;
using CBTPreparation.BuildingBlocks.Domain.Exceptions;
using CBTPreparation.Domain.StudentAggregate;

namespace CBTPreparation.Application.Features.FeedBack.GetFeedBack
{
    internal class FeedbackNotFoundException(FeedbackId feedbackId, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        : DomainException(string.Format(_messages, feedbackId), statusCode)
    {
        private const string _messages = "feedbackId `{0}` not found.";
    }
}
