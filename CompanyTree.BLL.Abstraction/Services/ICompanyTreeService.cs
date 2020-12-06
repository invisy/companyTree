using System;
using System.Collections.Generic;
using CompanyTree.Models.Abstractions;

namespace CompanyTree.BLL.Abstraction.Services
{
    public interface ICompanyTreeService
    {
        Employee GetRoot();
        IEnumerable<Employee> SetRoot(Employee root);
        IEnumerable<Employee> GetEmployeesWithMaxSalary(Employee root);
        IEnumerable<Employee> GetEmployeesWithHigherSalary(Employee root, int salary);
        IEnumerable<Employee> GetEmployeesWithPosition(Employee root, Position position);
        IEnumerable<Employee> GetDirectCompanyStructure(Employee root);
        IEnumerable<Employee> GetByPositionCompanyStructure(Employee root);
    }
}