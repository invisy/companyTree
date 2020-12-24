using System;
using CompanyTree.BLL.Abstraction.Services;
using CompanyTree.Models.Abstractions;
using CompanyTree.Models.Employees;
using CompanyTree.Models.Managers;

namespace CompanyTree.BLL.Implementation.Services
{
    public class LoaderServiceDummy : ILoaderService
    {
        public void setRoot(Employee employee)
        {
            CompanyTreeContainer.Root = employee;
        }

        public Employee getRoot()
        {
            return CompanyTreeContainer.Root;
        }

        public void LoadData()
        {
            Employee director = new Director("Director1", 5000);
            Employee salesManager = new SalesManager("SalesManager1", 3000, director);
            Employee supplyManager = new SupplyManager("SupplyManager1", 2500, director);
            Employee employeeA = new EmployeeA("EmployeeA1", 1500, salesManager);
            Employee employeeB = new EmployeeB("EmployeeB1", 1200, salesManager);
            salesManager.Add(employeeA);
            salesManager.Add(employeeB);
            director.Add(salesManager);
            director.Add(supplyManager);
            CompanyTreeContainer.Root = director;
        }

        public void SaveData()
        {
            throw new NotImplementedException();
        }
    }
}