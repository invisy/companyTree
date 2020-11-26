using System.Collections.Generic;
using CompanyTree.BLL.Abstraction.Visitors;
using CompanyTree.Models;
using CompanyTree.Models.Abstractions;
using CompanyTree.Models.Managers;

namespace CompanyTree.BLL.Implementation.Visitors
{
    public class WithMaxSalaryFinderVisitor : IWithMaxSalaryFinderVisitor
    {
        private readonly List<Employee> _employees;

        public WithMaxSalaryFinderVisitor()
        {
            _employees = new List<Employee>();
        }
        
        private void VisitComposite(Employee employee)
        {
            CheckMaxSalary(employee);
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
            CheckMaxSalary(employee);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employees;
        }

        private void CheckMaxSalary(Employee employee)
        {
            if (_employees.Count > 0 && _employees[0].Salary < employee.Salary)
            {
                _employees.Clear();
                _employees.Add(employee);
            }
            else if(_employees[0].Salary == employee.Salary)
            {
                _employees.Add(employee);
            }
        }
    }
}