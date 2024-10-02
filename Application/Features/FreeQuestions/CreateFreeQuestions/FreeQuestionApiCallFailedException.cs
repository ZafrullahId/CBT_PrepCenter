using CBTPreparation.BuildingBlocks.Domain.Exceptions;
using System.Net;

namespace CBTPreparation.Application.Features.FreeQuestions.CreateFreeQuestions
{
    public sealed class FreeQuestionApiCallFailedException(string url, HttpStatusCode statusCode = HttpStatusCode.BadGateway) 
        : DomainException(string.Format(_messages, url), statusCode)
    {
        private const string _messages = "Api call failed url: `{0}`";
    }
}
