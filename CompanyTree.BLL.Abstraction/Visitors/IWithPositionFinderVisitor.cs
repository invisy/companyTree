using System.Collections.Generic;
using CompanyTree.Models.Abstractions;

namespace CompanyTree.BLL.Abstraction.Visitors
{
    public interface IWithPositionFinderVisitor : IVisitor
    {
        IEnumerable<Employee> GetEmployees();
    }
}