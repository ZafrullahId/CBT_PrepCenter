﻿using CBTPreparation.BuildingBlocks.Domain.Exceptions;
using System.Net;

namespace CBTPreparation.Application.Features.Students.CreateStudent
{
    public sealed class StudentAlreadyExistException(string email, HttpStatusCode statusCode = HttpStatusCode.BadRequest) 
        : DomainException(string.Format(_messages, email), statusCode)
    {
        private const string _messages = "Student with The `{0}` already exists.";
    }
}
