using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchService.Exceptions
{
    public class FindException : System.Exception
    {
        public FindException() {}
        public FindException(string message) : base(message) {}
        public FindException(string message, System.Exception inner) : base(message, inner) {}
    }
}