using System.Net;
using Domain.Exceptions;

namespace Application.Features.FeedBack.GetFeedBack
{
    internal class FeedbackNotFoundException(Guid feedbackId, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        : DomainException(string.Format(_messages, feedbackId), statusCode)
    {
        private const string _messages = "feedbackId `{0}` not found.";
    }
}
