﻿using MediatR;

namespace Application.Features.Students.GetStudent
{
    public record GetStudentQuery(Guid StudentId) : IRequest<GetStudentQueryResponse>;
    
}