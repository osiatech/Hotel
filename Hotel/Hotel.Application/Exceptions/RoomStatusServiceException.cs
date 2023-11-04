using System;

namespace Hotel.Application.Exceptions
{
    public class RoomStatusServiceException : Exception
    {
        public RoomStatusServiceException(string message) : base(message)
        {

        }
    }
}
