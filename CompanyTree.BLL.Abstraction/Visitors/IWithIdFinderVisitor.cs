using CompanyTree.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyTree.BLL.Abstraction.Visitors
{
    public interface IWithIdFinderVisitor : IVisitor
    {
        int Id { get; set; }
        IEnumerable<Employee> GetEmployees();
    }
}
