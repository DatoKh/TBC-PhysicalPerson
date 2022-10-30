using System;

namespace Common.Shared.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException(string message)
           : base(message)
        {

        }
    }
}
