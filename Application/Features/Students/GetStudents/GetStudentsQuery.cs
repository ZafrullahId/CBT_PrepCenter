﻿using MediatR;

namespace Application.Features.Students.GetStudents
{
    public record GetStudentsQuery()  : IRequest<List<GetStudentsQueryResponse>>;
}