using System.Collections.Generic;
using CompanyTree.Models.Abstractions;
using CompanyTree.Models.Exceptions.Employee;

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
            throw new IsNotCompositeException();
        }

        public override IEnumerable<Employee> GetChildren()
        {
            throw new IsNotCompositeException();
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