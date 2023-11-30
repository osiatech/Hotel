
using System;
namespace Hotel.Application.Exceptions
{
    public class RecepcionServiceException : Exception
    {
        public RecepcionServiceException(string message) : base(message){}
    }
}
