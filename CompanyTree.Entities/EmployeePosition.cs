using System;

namespace CompanyTree.Entities
{
    public class EmployeePosition : BaseEntity<int>
    {
        private string PositionName { get; set; }
        private bool IsComposite { get; set; }
    }
}