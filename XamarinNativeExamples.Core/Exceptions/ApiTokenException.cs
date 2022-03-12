using System;

namespace XamarinNativeExamples.Core.Exceptions
{
    public class ApiTokenException : Exception
    {
        public ApiTokenException(string message) : base(message)
        {
        }
    }
}
