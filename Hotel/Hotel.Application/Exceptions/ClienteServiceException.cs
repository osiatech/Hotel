
using System;

namespace Hotel.Application.Exceptions
{
    public class ClienteServiceException : Exception
    {
        public ClienteServiceException(string message) : base(message) {}
    }
}
