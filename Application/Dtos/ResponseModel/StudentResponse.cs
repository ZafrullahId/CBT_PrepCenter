using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ResponseModel
{
    public class StudentResponse : BaseResponse
    {
        public StudentDto? Data { get; set; }
    }

    public class StudentsResponse : BaseResponse
    {
        public List<StudentDto>? Data { get; set; }

    }
}
