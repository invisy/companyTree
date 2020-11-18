using CompanyTree.Models.Abstractions;

namespace CompanyTree.Models
{
    public class EmployeeLeaf : Employee
    {
        public bool IsComposite() 
        {
            return false;
        }

        public EmployeeLeaf(string name, int salary, int positionId, int? supervisorId) 
                            : base(name, salary, positionId, supervisorId)
        {
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            throw new System.NotImplementedException();
        }
    }
}