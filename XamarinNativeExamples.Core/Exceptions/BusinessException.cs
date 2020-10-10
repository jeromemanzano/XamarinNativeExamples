using System;
using System.Runtime.Serialization;

namespace XamarinNativeExamples.Core.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException() 
        { 
        }

        public BusinessException(string message) : base(message)
        {
        }

        protected BusinessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public BusinessException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
