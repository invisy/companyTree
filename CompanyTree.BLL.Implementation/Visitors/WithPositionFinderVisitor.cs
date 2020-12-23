using System.Collections.Generic;
using CompanyTree.BLL.Abstraction.Visitors;
using CompanyTree.Models;
using CompanyTree.Models.Abstractions;
using CompanyTree.Models.Managers;

namespace CompanyTree.BLL.Implementation.Visitors
{
    public class WithPositionFinderVisitor : IWithPositionFinderVisitor
    {
        private readonly List<Employee> _employees;
        public Position Position { get; set; } = 0;

        public WithPositionFinderVisitor()
        {
            _employees = new List<Employee>();
        }
        
        private void VisitComposite(Employee employee)
        {
            if(employee.Position == Position)
                _employees.Add(employee);
            
            IEnumerable<Employee> subEmployees = employee.GetChildren();
            foreach (Employee subEmployee in subEmployees)
            {
                subEmployee.Accept(this);
            }
        }
        public void Visit(Director employee)
        {
            VisitComposite(employee);
        }

        public void Visit(Manager employee)
        {
            VisitComposite(employee);
        }

        public void Visit(SimpleEmployee employee)
        {
            if(employee.Position == Position)
                _employees.Add(employee);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            List<Employee> clone = new List<Employee>(_employees);
            _employees.Clear();
            return clone;
        }
    }
}