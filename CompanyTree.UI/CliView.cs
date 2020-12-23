using System;
using System.Collections.Generic;
using CompanyTree.UI.Exceptions;

namespace CompanyTree.UI
{
    public class CliView
    {
        public void Main()
        {
            Console.WriteLine("\t Select option: \n" +
                              "1. Add Employee \n" +
                              "2. Show list of employees \n" +
                              "3. Find employees with max salary \n" +
                              "4. Find employees with higher salary \n" +
                              "5. Find employees with position \n" +
                              "0. Exit \n");
        }
        
        public void SelectViewOrderMenu()
        {
            Console.WriteLine("\t Select option: \n" +
                              "1. Direct order \n" +
                              "2. By position \n" +
                              "0. Exit \n");
        }
        
        public void ShowEmployeeList(List<string> employees)
        {
            foreach (string employee in employees)
            {
                Console.WriteLine($"\t - {employee}");
            }
        }
        
        public void SelectByEmployeeList(List<string> employees)
        {
            Console.WriteLine("\t Select option: \n" +
                              "0. - \n");
            for (int i = 0; i < employees.Count;i++)
            {
                Console.WriteLine($"{i+1}. {employees[i]}");
            }
        }
        
        public void PrintSalaryDialog()
        {
            Console.WriteLine("\t Print salary: \n");
        }
        
        public void PrintNameDialog()
        {
            Console.WriteLine("\t Print name: \n");
        }

        public void SelectPosition()
        {
            Console.WriteLine("\t Select option: \n" +
                              "1. Director \n" +
                              "2. Supply Manager \n" +
                              "3. Sales Manager \n" +
                              "4. EmployeeA \n" +
                              "5. EmployeeB \n" +
                              "6. EmployeeX \n" +
                              "7. EmployeeY \n");
        }
    }
}