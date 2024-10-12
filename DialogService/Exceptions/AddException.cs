using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DialogService.Exceptions
{
    [System.Serializable]
    public class AddException : System.Exception
    {
        public AddException() { }
        public AddException(string message) : base(message) { }
        public AddException(string message, System.Exception inner) : base(message, inner) { }
        protected AddException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}