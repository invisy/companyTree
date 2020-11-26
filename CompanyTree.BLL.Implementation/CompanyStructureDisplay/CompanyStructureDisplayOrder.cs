using System.Collections.Generic;
using CompanyTree.BLL.Abstraction;
using CompanyTree.BLL.Abstraction.CompanyStructureDisplay;
using CompanyTree.Entities;
using CompanyTree.Models.Abstractions;

namespace CompanyTree.BLL.Implementation.CompanyStructureDisplay
{
    public class CompanyStructureDisplayOrder : ICompanyStructureDisplayOrder
    {
        public IDisplayOrderStrategy Strategy { get; set; }
        
        public CompanyStructureDisplayOrder(IDisplayOrderStrategy strategy)
        {
            this.Strategy = strategy;
        }

        public IEnumerable<Employee> GetStructure(Employee employee)
        {
            return Strategy.GetStructure(employee);
        }
    }
}