using CompanyTree.Models.Abstractions;
using CompanyTree.Models.Managers;

namespace CompanyTree.Models.Managers
{
    public class Manager : EmployeeComposite
    {
        protected Manager(string name, int salary, Position position, Employee supervisor) : base(name, salary, position)
        {
            this.Supervisor = supervisor;
        }
        
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
        
        public override bool HasSupervisor()
        {
            return true;
        }
    }
}