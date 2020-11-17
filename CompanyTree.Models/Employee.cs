using System;

namespace CompanyTree.Models
{
    public abstract class Employee : BaseModel<int>
    {
        private string name;
        private int salary;
        private Type position;
        private Employee supervisor;
    }
}