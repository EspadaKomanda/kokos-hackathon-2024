using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchService.Exceptions
{
    public class UpdateException : System.Exception
    {
        public UpdateException() {}
        public UpdateException(string message) : base(message) {}
        public UpdateException(string message, System.Exception inner) : base(message, inner) {}
    }
}