using System.Collections.Generic;
using CompanyTree.Models.Abstractions;

namespace CompanyTree.Models
{
    public class SimpleEmployee : Employee
    {
        protected SimpleEmployee(string name, int salary, Position position, Employee supervisor) 
            : base(name, salary, position)
        {
            this.Supervisor = supervisor;
        }

        public override void Add(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public override void Remove(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<Employee> GetChildren()
        {
            throw new System.NotImplementedException();
        }

        public override bool HasSupervisor()
        {
            return true;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
        
        public override bool IsComposite() 
        {
            return false;
        }
    }
}