using System.Collections.Generic;
using CompanyTree.BLL.Abstraction;
using CompanyTree.BLL.Abstraction.CompanyStructureDisplay;
using CompanyTree.Models.Abstractions;

namespace CompanyTree.BLL.Implementation.CompanyStructureDisplay
{
    public class CompanyStructureByPositionStrategy : ICompanyStructureByPositionStrategy
    {
        private List<Employee> _employees;
        
        public IEnumerable<Employee> GetStructure(Employee employee)
        {
            _employees = new List<Employee>();
            _employees.Add(employee);
            if (employee.IsComposite())
                GetNext(employee.GetChildren());
            return _employees;
        }

        private void GetNext(IEnumerable<Employee> employee)
        {
            List<Employee> children = new List<Employee>();
            
            foreach (var subEmployee in employee)
            {
                _employees.Add(subEmployee);
                if (subEmployee.IsComposite())
                {
                    foreach (var subSubEmployee in subEmployee.GetChildren())
                    {
                        children.Add(subSubEmployee);
                    }
                }
            }
            if(children.Count > 0)
                GetNext(children);
        }
    }
}