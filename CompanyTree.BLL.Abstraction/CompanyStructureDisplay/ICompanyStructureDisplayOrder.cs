using System.Collections.Generic;
using CompanyTree.Models.Abstractions;

namespace CompanyTree.BLL.Abstraction.CompanyStructureDisplay
{
    public interface ICompanyStructureDisplayOrder
    {
        IDisplayOrderStrategy Strategy { get; set; }
        IEnumerable<Employee> GetStructure(Employee employee);
    }
}