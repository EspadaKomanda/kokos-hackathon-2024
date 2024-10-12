using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DialogService.Exceptions
{
    public class GetException : System.Exception
    {
        public GetException() {}
        public GetException(string message) : base(message) {}
        public GetException(string message, System.Exception inner) : base(message, inner) {}
    }
}