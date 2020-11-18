using System.Collections.Generic;
using CompanyTree.Models.Abstractions;

namespace CompanyTree.Models
{
    public class EmployeeComposite : Employee
    {
        private readonly List<Employee> _children;

        public EmployeeComposite(string name, int salary, int positionId, int? supervisorId) 
                                :base(name, salary, positionId, supervisorId)
        {
            _children = new List<Employee>();
        }
        
        public virtual void Add(Employee component)
        {
            _children.Add(component);
        }

        public virtual void Remove(Employee component)
        {
            _children.Remove(component);
        }

        public virtual IEnumerable<Employee> GetChildren(Employee component)
        {
            return _children;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}