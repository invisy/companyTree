using System.Collections.Generic;
using CompanyTree.BLL.Abstraction.Visitors;
using CompanyTree.Models;
using CompanyTree.Models.Abstractions;
using CompanyTree.Models.Managers;

namespace CompanyTree.BLL.Implementation.Visitors
{
    public class WithHigherSalaryFinderVisitor : IWithHigherSalaryFinderVisitor
    {
        private readonly List<Employee> _employees;
        private readonly int _salary;

        public WithHigherSalaryFinderVisitor(int salary)
        {
            _employees = new List<Employee>();
            _salary = salary;
        }
        
        private void VisitComposite(Employee employee)
        {
            if(employee.Salary > _salary)
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
            if(employee.Salary > _salary)
                _employees.Add(employee);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employees;
        }
    }
}