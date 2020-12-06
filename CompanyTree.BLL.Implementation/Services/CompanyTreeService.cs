using System.Collections.Generic;
using CompanyTree.BLL.Abstraction.CompanyStructureDisplay;
using CompanyTree.BLL.Abstraction.Services;
using CompanyTree.BLL.Abstraction.Visitors;
using CompanyTree.BLL.Implementation.Visitors;
using CompanyTree.Models.Abstractions;

namespace CompanyTree.BLL.Implementation.Services
{
    public class CompanyTreeService : ICompanyTreeService
    {
        private readonly TreeContainer _treeContainer;
        
        private readonly IWithHigherSalaryFinderVisitor _withHigherSalaryFinderVisitor;
        private readonly IWithMaxSalaryFinderVisitor _withMaxSalaryFinderVisitor;
        private readonly IWithPositionFinderVisitor _withPositionFinderVisitor;
        
        private readonly ICompanyStructureDisplayOrder _displayOrder;
        private readonly ICompanyStructureDirectStrategy _directStrategy;
        private readonly ICompanyStructureByPositionStrategy _byPositionStrategy;
        
        public CompanyTreeService(IWithHigherSalaryFinderVisitor withHigherSalaryFinderVisitor
            , IWithMaxSalaryFinderVisitor withMaxSalaryFinderVisitor, IWithPositionFinderVisitor withPositionFinderVisitor
            ,ICompanyStructureDisplayOrder displayOrder, ICompanyStructureDirectStrategy directStrategy
            , ICompanyStructureByPositionStrategy byPositionStrategy, TreeContainer treeContainer)
        {
            _withHigherSalaryFinderVisitor = withHigherSalaryFinderVisitor;
            _withMaxSalaryFinderVisitor = withMaxSalaryFinderVisitor;
            _withPositionFinderVisitor = withPositionFinderVisitor;
            _displayOrder = displayOrder;
            _directStrategy = directStrategy;
            _byPositionStrategy = byPositionStrategy;
            _treeContainer = treeContainer;
        }

        public Employee GetRoot()
        {
            return _treeContainer.Root;
        }

        public void SetRoot(Employee employee)
        {
            _treeContainer.Root = employee;
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
            _displayOrder.Strategy = _directStrategy;
            return _displayOrder.GetStructure(employee);
        }

        public IEnumerable<Employee> GetByPositionCompanyStructure(Employee employee)
        {
            _displayOrder.Strategy = _byPositionStrategy;
            return _displayOrder.GetStructure(employee);
        }
    }
}