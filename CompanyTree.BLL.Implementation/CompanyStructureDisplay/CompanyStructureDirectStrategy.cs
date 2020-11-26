using System;
using System.Collections.Generic;
using CompanyTree.BLL.Abstraction;
using CompanyTree.BLL.Abstraction.CompanyStructureDisplay;
using CompanyTree.Models.Abstractions;

namespace CompanyTree.BLL.Implementation.CompanyStructureDisplay
{
    public class CompanyStructureDirectStrategy : ICompanyStructureDirectStrategy
    {
        private List<Employee> _employees;
        
        public IEnumerable<Employee> GetStructure(Employee employee)
        {
            _employees = new List<Employee>();
            GetNext(employee);
            return _employees;
        }

        private void GetNext(Employee employee)
        {
            _employees.Add(employee);

            IEnumerable<Employee> children = employee.GetChildren();

            foreach (var subEmployee in children)
            {
                if(subEmployee.IsComposite())
                    GetNext(subEmployee);
            }
        }
    }
}