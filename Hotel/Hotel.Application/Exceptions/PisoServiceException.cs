using System;

namespace Hotel.Application.Excepctions
{
    public class PisoServiceException : Exception
    {
        public PisoServiceException(string message) : base(message)
        {

        }
    }
}