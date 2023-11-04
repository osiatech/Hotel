using System;

namespace Hotel.Application.Exceptions
{
    public class UserRolServiceException : Exception
    {
        public UserRolServiceException(string message) : base(message)
        {

        }
    }
}
