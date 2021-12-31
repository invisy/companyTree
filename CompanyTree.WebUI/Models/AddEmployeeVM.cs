using CompanyTree.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyTree.WebUI.Models
{
    public class AddEmployeeVM
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public Position Position { get; set; }
        public IEnumerable<Employee> Parent { get; set; }
        public int SelectedParentId { get; set; }
        public IEnumerable<Employee> Supervisor { get; set; }
        public int SelectedSupervisorId { get; set; }
    }
}
