using CompanyTree.Models.Abstractions;

namespace CompanyTree.Models.Employees
{
    public class EmployeeA : SimpleEmployee
    {
        protected EmployeeA(string name, int salary, Employee supervisor) 
            : base(name, salary, Position.EmployeeA, supervisor)
        {
        }
    }
}