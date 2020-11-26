using CompanyTree.Models.Abstractions;

namespace CompanyTree.Models.Employees
{
    public class EmployeeX : SimpleEmployee
    {
        protected EmployeeX(string name, int salary, Employee supervisor) 
            : base(name, salary, Position.EmployeeX, supervisor)
        {
        }
    }
}