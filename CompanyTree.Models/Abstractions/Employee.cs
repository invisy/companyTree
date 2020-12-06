using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CompanyTree.Models.Abstractions
{
    public abstract class Employee : BaseModel<int>, IVisitable
    {
        public string Name { get; private set; }
        public int Salary { get; private set; }
        public Position Position { get; private set; }
        public Employee Supervisor { get; protected set; }
        
        public abstract bool IsComposite();

        public abstract void Add(Employee employee);
        public abstract void Remove(Employee employee);
        public abstract IEnumerable<Employee> GetChildren();

        public abstract bool HasSupervisor();
        public abstract void Accept(IVisitor visitor);

        protected Employee(string name, int salary, Position position)
        {
            Name = name;
            Salary = salary;
            Position = position;
        }
    }
}