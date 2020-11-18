using System;

namespace CompanyTree.Models.Abstractions
{
    public abstract class Employee : BaseModel<int>, IVisitable
    {
        public string Name { get; private set; }
        public int Salary { get; private set; }
        public int PositionId { get; private set; }
        public int? SupervisorId { get; private set; }
        
        public abstract void Accept(IVisitor visitor);

        protected Employee(string name, int salary, int positionId, int? supervisorId)
        {
            Name = name;
            Salary = salary;
            PositionId = positionId;
            SupervisorId = supervisorId;
        }
    }
}