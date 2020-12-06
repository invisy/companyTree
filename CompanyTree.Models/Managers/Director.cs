using CompanyTree.Models.Abstractions;

namespace CompanyTree.Models.Managers
{
    public class Director : EmployeeComposite
    {
        public Director(string name, int salary) : base(name, salary, Position.Director)
        {
        }
        
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
        
        public override bool HasSupervisor()
        {
            return false;
        }
    }
}