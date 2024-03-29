﻿using System;
using System.Collections.Generic;
using CompanyTree.Models.Abstractions;

namespace CompanyTree.Models
{
    public class EmployeeComposite : Employee
    {
        private readonly List<Employee> _children;

        protected EmployeeComposite(string name, int salary, Position position) 
            :base(name, salary, position)
        {
            _children = new List<Employee>();
        }
        
        public override void Add(Employee component)
        {
            if(component is null)
                throw new ArgumentNullException("Can`t add null employee");
            _children.Add(component);
        }

        public override IEnumerable<Employee> GetChildren()
        {
            return _children;
        }

        public override bool HasSupervisor()
        {
            throw new System.NotImplementedException();
        }

        public override void Accept(IVisitor visitor)
        {
            throw new System.NotImplementedException();
        }

        public override bool IsComposite() 
        {
            return true;
        }
    }
}