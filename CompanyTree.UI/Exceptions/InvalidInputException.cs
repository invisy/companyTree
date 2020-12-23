using System;

namespace CompanyTree.UI.Exceptions
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException() : base()
        {
            
        }
        public InvalidInputException(string message) : base(message)
        {
            
        }
    }
}