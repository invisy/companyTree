using System;
using System.Collections.Generic;
using CompanyTree.Models.Abstractions;

namespace CompanyTree.BLL.Abstraction.Services
{
    public interface ICompanyTreeStructuringService
    {
        IEnumerable<Employee> GetDirectCompanyStructure(Employee root);
        IEnumerable<Employee> GetByPositionCompanyStructure(Employee root);
    }
}