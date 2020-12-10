using System.Collections.Generic;
using CompanyTree.BLL.Abstraction.CompanyStructureDisplay;
using CompanyTree.BLL.Abstraction.Services;
using CompanyTree.Models.Abstractions;

namespace CompanyTree.BLL.Implementation.Services
{
    public class CompanyTreeStructuringService : ICompanyTreeStructuringService
    {
        private readonly ICompanyStructureDisplayOrder _displayOrder;
        private readonly ICompanyStructureDirectStrategy _directStrategy;
        private readonly ICompanyStructureByPositionStrategy _byPositionStrategy;
        
        public CompanyTreeStructuringService(ICompanyStructureDisplayOrder displayOrder, ICompanyStructureDirectStrategy directStrategy
            , ICompanyStructureByPositionStrategy byPositionStrategy)
        {
            _displayOrder = displayOrder;
            _directStrategy = directStrategy;
            _byPositionStrategy = byPositionStrategy;
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