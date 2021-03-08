using System;
using System.Runtime.Serialization;

namespace mm_exceptions
{
    [Serializable]//Can be Serialized
    public class MovieManagementException : Exception//Inherits exception
    {
        public MovieManagementException()
        {
        }

        //Can change the Exception message for base Exception
        public MovieManagementException(string message) : base(message)
        {
        }
        //Can change the Exception message for derived Exception
        public MovieManagementException(string message, Exception innerException) : base(message, innerException)
        {
        }
        //Derived exeption can be serialized
        protected MovieManagementException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

