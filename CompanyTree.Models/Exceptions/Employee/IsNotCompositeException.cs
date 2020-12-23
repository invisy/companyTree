﻿﻿using System;

namespace CompanyTree.Models.Exceptions.Employee
{
    public class IsNotCompositeException : Exception
    {
        public IsNotCompositeException() : base()
        {
            
        }
        public IsNotCompositeException(string message) : base(message)
        {
            
        }
    }
}