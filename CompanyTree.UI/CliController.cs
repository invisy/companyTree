using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using CompanyTree.BLL.Abstraction.Services;
using CompanyTree.Models.Abstractions;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace CompanyTree.UI
{
    public class CliController
    {
        private CliView _view;
        private ICompanyTreeService _companyTreeService;

        public CliController(ICompanyTreeService companyTreeService, CliView cliView)
        {
            _companyTreeService = companyTreeService;
            _view = cliView;
        }
        
        public void ShowMenu()
        {
            MainMenu userVariant = (MainMenu)(_view.Main());
            Employee root = _companyTreeService.GetRoot();
            List<String> employees;
            switch (userVariant)
            {
                case MainMenu.AddEmployee:
                    AddEmployee();
                    break;
                case MainMenu.SelectFindWithMaxSalary:
                    employees = _companyTreeService.GetEmployeesWithMaxSalary(root).Select(x => x.Name).ToList();
                    _view.ShowEmployeeList(employees);
                    break;
                case MainMenu.SelectFindWithHigherSalary:
                    employees = _companyTreeService.GetEmployeesWithHigherSalary(root, 10).Select(x => x.Name).ToList();
                    _view.ShowEmployeeList(employees);
                    break;
                case MainMenu.SelectFindWithPosition:
                    employees = _companyTreeService.GetEmployeesWithPosition(root, Position.Director).Select(x => x.Name).ToList();
                    _view.ShowEmployeeList(employees);
                    break;
                case MainMenu.Exit:
                    Environment.Exit(0);
                    break;
            }
            
        }

        private void AddEmployee()
        {
            int position = _view.SelectPosition();
            string name = _view.PrintName();
            int salary = _view.PrintSalary();
        }
    }
}