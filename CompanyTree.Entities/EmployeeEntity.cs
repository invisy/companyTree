namespace CompanyTree.Entities
{
    public class EmployeeEntity : BaseEntity<int>
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public EmployeePosition Position { get; set; }
        public EmployeeEntity Supervisor { get; set; }
    }
}