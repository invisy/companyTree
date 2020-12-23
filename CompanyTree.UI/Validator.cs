using System;
using CompanyTree.UI.Exceptions;

namespace CompanyTree.UI
{
    public static class Validator
    {
        public static int ValidateNumber(string textNumber, int min, int max)
        {
            if(!int.TryParse(textNumber, out int number))
                throw new InvalidInputException("Input value isn`t number");
            
            if (number < min || number > max)
                throw new InvalidInputException("Validated number is out of range!");
            return number;
        }
        
        public static string ValidateText(string text, int min, int max)
        {
            if (text.Length < min || text.Length > max)
                throw new InvalidInputException("Text length is out of range!");
            return text;
        }
    }
}