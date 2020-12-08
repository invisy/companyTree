using System;
using System.Collections.Generic;
using CompanyTree.UI.Exceptions;

namespace CompanyTree.UI
{
    public class CliView
    {
        public int Main()
        {
            Console.WriteLine("\t Select option: \n" +
                              "1. Add Employee \n" +
                              "2. Find employees with max salary \n" +
                              "3. Find employees with higher salary \n" +
                              "4. Find employees with position \n" +
                              "0. Exit \n");
            string value = Console.ReadLine();
            return GetNumber(value);
        }
        
        public int ShowEmployeeList(List<string> employees)
        {
            foreach (string employee in employees)
            {
                Console.WriteLine($"\t - {employee}");
            }
            Console.WriteLine("\t Select option: \n" +
                              "0. Go to main \n");
            string value = Console.ReadLine();
            return GetNumber(value);
        }
        
        public int SelectByEmployeeList(List<string> employees)
        {
            Console.WriteLine("\t Select option: \n");
            for (int i = 0; i < employees.Count;i++)
            {
                Console.WriteLine($"{i}. {employees[0]}");
            }
            Console.WriteLine("0. Go to main \n");
            string value = Console.ReadLine();
            return GetNumber(value);
        }
        
        public int PrintSalaryDialog()
        {
            Console.WriteLine("\t Print salary: \n");
            string value = Console.ReadLine();
            return GetNumber(value);
        }
        
        public string PrintNameDialog()
        {
            Console.WriteLine("\t Print name: \n");
            return Console.ReadLine();
        }

        public int SelectPosition()
        {
            Console.WriteLine("\t Select option: \n" +
                              "1. Director \n" +
                              "2. Supply Manager \n" +
                              "3. Sales Manager \n" +
                              "4. EmployeeA \n" +
                              "5. EmployeeB \n" +
                              "6. EmployeeX \n" +
                              "7. EmployeeY \n" +
                              "0. Go to main \n");
            string value = Console.ReadLine();
            return GetNumber(value);
        }

        private int GetNumber(string textNumber)
        {
            int value = 0;
            if(!int.TryParse(textNumber, out value))
                throw new InvalidInputException();
            return value;
        }
    }
}