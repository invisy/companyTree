using System.Collections.Generic;

namespace CompanyTree.Models
{
    public abstract class EmployeeComposite
    {
        private List<Employee> children = new List<Employee>();
        
        public virtual void Add(Employee component)
        {
            children.Add(component);
        }

        public virtual void Remove(Employee component)
        {
            children.Remove(component);
        }

        public virtual IEnumerable<Employee> GetChildren(Employee component)
        {
            return children;
        }
    }
}