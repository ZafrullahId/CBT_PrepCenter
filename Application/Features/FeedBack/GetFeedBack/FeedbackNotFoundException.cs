using Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FeedBack.GetFeedBack
{
    internal class FeedbackNotFoundException(Guid feedbackId, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        : BaseException(string.Format(_messages, feedbackId), statusCode)
    {
        private const string _messages = "feedbackId `{0}` not found.";
    }
}
