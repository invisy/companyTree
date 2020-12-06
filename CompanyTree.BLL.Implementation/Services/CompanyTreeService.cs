using System.Collections.Generic;
using CompanyTree.BLL.Abstraction.Services;
using CompanyTree.BLL.Abstraction.Visitors;
using CompanyTree.BLL.Implementation.Visitors;
using CompanyTree.Models.Abstractions;

namespace CompanyTree.BLL.Implementation.Services
{
    public class CompanyTreeService : ICompanyTreeService
    {
        private readonly IWithHigherSalaryFinderVisitor _withHigherSalaryFinderVisitor;
        private readonly IWithMaxSalaryFinderVisitor _withMaxSalaryFinderVisitor;
        private readonly IWithPositionFinderVisitor _withPositionFinderVisitor;
        
        public CompanyTreeService(IWithHigherSalaryFinderVisitor withHigherSalaryFinderVisitor
            , IWithMaxSalaryFinderVisitor withMaxSalaryFinderVisitor, IWithPositionFinderVisitor withPositionFinderVisitor)
        {
            _withHigherSalaryFinderVisitor = withHigherSalaryFinderVisitor;
            _withMaxSalaryFinderVisitor = withMaxSalaryFinderVisitor;
            _withPositionFinderVisitor = withPositionFinderVisitor;
        }

        public Employee GetRoot()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Employee> SetRoot(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Employee> GetEmployeesWithMaxSalary(Employee employee)
        {
            var visitor = _withMaxSalaryFinderVisitor;
            employee.Accept(visitor);

            return visitor.GetEmployees();
        }

        public IEnumerable<Employee> GetEmployeesWithHigherSalary(Employee employee, int salary)
        {
            var visitor = _withHigherSalaryFinderVisitor;
            visitor.Salary = salary;
            employee.Accept(visitor);

            return visitor.GetEmployees();
        }

        public IEnumerable<Employee> GetEmployeesWithPosition(Employee employee, Position position)
        {
            var visitor = _withPositionFinderVisitor;
            visitor.Position = position;
            employee.Accept(visitor);

            return visitor.GetEmployees();
        }

        public IEnumerable<Employee> GetDirectCompanyStructure(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Employee> GetByPositionCompanyStructure(Employee employee)
        {
            throw new System.NotImplementedException();
        }
    }
}