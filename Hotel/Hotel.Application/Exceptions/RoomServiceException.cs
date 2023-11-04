using System;

namespace Hotel.Application.Exceptions
{
    public class RoomServiceException : Exception
    {
        public RoomServiceException(string message) : base(message)
        {

        }
    }
}
