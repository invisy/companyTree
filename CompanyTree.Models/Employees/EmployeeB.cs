using CompanyTree.Models.Abstractions;

namespace CompanyTree.Models.Employees
{
    public class EmployeeB : SimpleEmployee
    {
        public EmployeeB(string name, int salary, Employee supervisor) 
            : base(name, salary, Position.EmployeeB, supervisor)
        {
        }
    }
}