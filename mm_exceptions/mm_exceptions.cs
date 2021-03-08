using System;
using System.Runtime.Serialization;

namespace mm_exceptions
{
    [Serializable]
    public class MovieManagementException : Exception
    {
        public MovieManagementException()
        {
        }

        public MovieManagementException(string message) : base(message)
        {
        }

        public MovieManagementException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MovieManagementException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

