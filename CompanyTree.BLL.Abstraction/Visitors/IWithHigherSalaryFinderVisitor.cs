using System.Collections.Generic;
using CompanyTree.Models.Abstractions;

namespace CompanyTree.BLL.Abstraction.Visitors
{
    public interface IWithHigherSalaryFinderVisitor : IVisitor
    {
        IEnumerable<Employee> GetEmployees();
    }
}