using CompanyTree.Models.Abstractions;

namespace CompanyTree.Models.Employees
{
    public class EmployeeY : SimpleEmployee
    {
        protected EmployeeY(string name, int salary, Employee supervisor) 
            : base(name, salary, Position.EmployeeY, supervisor)
        {
        }
    }
}