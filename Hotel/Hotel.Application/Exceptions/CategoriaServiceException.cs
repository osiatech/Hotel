using System;

namespace Hotel.Application.Excepctions
{
    public class CategoriaServiceException : Exception
    {
        public CategoriaServiceException(string message) : base(message)
        {
            
        }
    }
}