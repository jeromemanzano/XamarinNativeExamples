using System;
using System.Runtime.Serialization;

namespace XamarinNativeExamples.Core.Exceptions
{
    public class ApiTokenException : Exception
    {
        public ApiTokenException()
        {
        }

        public ApiTokenException(string message) : base(message)
        {
        }

        protected ApiTokenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ApiTokenException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
