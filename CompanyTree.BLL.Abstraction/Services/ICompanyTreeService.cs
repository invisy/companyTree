using System.Collections.Generic;
using CompanyTree.Models.Abstractions;

namespace CompanyTree.BLL.Abstraction.Services
{
    public interface ICompanyTreeService
    {
        IEnumerable<Employee> GetEmployeesWithMaxSalary(Employee employee);
        IEnumerable<Employee> GetEmployeesWithHigherSalary(Employee employee, int salary);
        IEnumerable<Employee> GetEmployeesWithPosition(Employee employee, Position position);
        IEnumerable<Employee> GetDirectCompanyStructure(Employee employee);
        IEnumerable<Employee> GetByPositionCompanyStructure(Employee employee);
    }
}