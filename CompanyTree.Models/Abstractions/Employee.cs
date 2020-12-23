using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CompanyTree.Models.Abstractions
{
    public abstract class Employee : BaseModel<int>, IVisitable
    {
        public string Name { get;  }
        public int Salary { get;  }
        public Position Position { get; }
        public Employee Supervisor { get; protected set; }
        
        public abstract bool IsComposite();

        public abstract void Add(Employee employee);
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