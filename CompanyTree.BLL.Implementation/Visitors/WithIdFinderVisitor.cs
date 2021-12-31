using System.Collections.Generic;
using CompanyTree.BLL.Abstraction.Visitors;
using CompanyTree.Models;
using CompanyTree.Models.Abstractions;
using CompanyTree.Models.Managers;

namespace CompanyTree.BLL.Implementation.Visitors
{
    public class WithIdFinderVisitor : IWithIdFinderVisitor
    {
        private readonly List<Employee> _employees;
        public int Id { get; set; } = 0;

        public WithIdFinderVisitor()
        {
            _employees = new List<Employee>();
        }
        
        private void VisitComposite(Employee employee)
        {
            if(employee.Id == Id)
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
            if(employee.Id == Id)
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