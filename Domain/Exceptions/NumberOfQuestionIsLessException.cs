using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    internal class NumberOfQuestionIsLessException : DomainException
    {
        public NumberOfQuestionIsLessException(string message):base(message)
        {
            
        }
    }
}
