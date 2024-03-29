﻿using System;
using System.Collections.Generic;
using CompanyTree.Models.Abstractions;

namespace CompanyTree.BLL.Abstraction.Services
{
    public interface ICompanyTreeFinderService
    {
        IEnumerable<Employee> GetEmployeesWithMaxSalary(Employee root);
        IEnumerable<Employee> GetEmployeesWithHigherSalary(Employee root, int salary);
        IEnumerable<Employee> GetEmployeesWithPosition(Employee root, Position position);
        IEnumerable<Employee> GetEmployeesWithId(Employee root, int id);
    }
}