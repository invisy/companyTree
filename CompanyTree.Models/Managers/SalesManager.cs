using CompanyTree.Models.Abstractions;

namespace CompanyTree.Models.Managers
{
    public class SalesManager : Manager
    {
        public SalesManager(string name, int salary, Employee supervisor) 
            : base(name, salary, Position.SalesManager, supervisor)
        {
        }
    }
}