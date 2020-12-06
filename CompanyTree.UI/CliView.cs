using System;
using System.Collections.Generic;

namespace CompanyTree.UI
{
    public enum MainMenu
    {
        AddEmployee,
        SelectFindWithMaxSalary,
        SelectFindWithHigherSalary,
        SelectFindWithPosition
    }
    public class CliView
    {
        public short Main()
        {
            Console.WriteLine("\t Select option: \n" +
                              "1. Add Employee \n" +
                              "2. Find employees with max salary \n" +
                              "3. Find employees with higher salary \n" +
                              "4. Find employees with position \n");
            String value = Console.ReadLine();
            return short.Parse(value);
        }
        
        public short ShowEmployeeList(List<String> employees)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine($"\t - {employee}");
            }
            Console.WriteLine("\t Select option: \n" +
                              "1. Go to main \n");
            String value = Console.ReadLine();
            return short.Parse(value);
        }
        
        public short SelectByEmployeeList(List<String> employees)
        {
            Console.WriteLine("\t Select option: \n");
            for (int i = 0; i<employees.Count;i++)
            {
                Console.WriteLine($"{i}. {employees[0]}");
            }
            Console.WriteLine($"{employees.Count+1}. Go to main \n");
            String value = Console.ReadLine();
            return short.Parse(value);
        }
        
        public int PrintSalary()
        {
            Console.WriteLine("\t Print salary: \n");
            String value = Console.ReadLine();
            return int.Parse(value);
        }
        
        public String PrintName()
        {
            Console.WriteLine("\t Print name: \n");
            return Console.ReadLine();
        }

        public short SelectPosition()
        {
            Console.WriteLine("\t Select option: \n" +
                              "1. Director \n" +
                              "2. Supply Manager \n" +
                              "3. Sales Manager \n" +
                              "4. EmployeeA \n" +
                              "5. EmployeeB \n" +
                              "6. EmployeeX \n" +
                              "7. EmployeeY \n" +
                              "8. Go to main \n");
            String value = Console.ReadLine();
            return short.Parse(value);
        }
    }
}