﻿using CBTPreparation.Application.Abstractions.Repositories;
using CBTPreparation.Application.Shared;
using MediatR;

namespace CBTPreparation.Application.Features.Students.GetStudent
{
    public class GetStudentQueryHandler(IStudentRepository _studentRepository) : IRequestHandler<GetStudentQuery, GetStudentQueryResponse>
    {
        public async Task<GetStudentQueryResponse> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetAsync(request.StudentId, cancellationToken);

            return student is null
                ? throw new StudentNotFoundException(request.StudentId)
                : new GetStudentQueryResponse(
               student.User.FirstName,
               student.User.LastName,
               student.User.Email,
                new BaseResponse(
                "Student Retrieved Successfully",
                true));
        }
    }
}
