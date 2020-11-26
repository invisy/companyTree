using CompanyTree.Models.Abstractions;

namespace CompanyTree.Models.Managers
{
    public class SupplyManager : Manager
    {
        protected SupplyManager(string name, int salary, Employee supervisor) 
            : base(name, salary, Position.SupplyManager, supervisor)
        {
        }
    }
}