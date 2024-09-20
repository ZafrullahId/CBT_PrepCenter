using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FreeQuestions.CreateFreeQuestions
{
    public sealed class FreeQuestionApiCallFailedException(string url, HttpStatusCode statusCode = HttpStatusCode.BadGateway) 
        : DomainException(string.Format(_messages, url), statusCode)
    {
        private const string _messages = "Api call failed url: `{0}`";
    }
}
