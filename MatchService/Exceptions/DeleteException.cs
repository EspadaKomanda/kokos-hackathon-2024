using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchService.Exceptions
{
    public class DeleteException : System.Exception
    {
        public DeleteException() {}
        public DeleteException(string message) : base(message) {}
        public DeleteException(string message, System.Exception inner) : base(message, inner) {}
    }
}