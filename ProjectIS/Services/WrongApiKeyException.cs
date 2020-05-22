using System;
using System.Runtime.Serialization;

namespace ProjectIS.Services
{
    [Serializable]
    internal class WrongApiKeyException : Exception
    {
        public WrongApiKeyException()
        {
        }

        public WrongApiKeyException(string message) : base(message)
        {
        }

        public WrongApiKeyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WrongApiKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}