using System;
using System.Collections.Generic;
using System.Linq;
using CompanyTree.BLL.Abstraction.Services;
using CompanyTree.Models.Abstractions;
using CompanyTree.UI.Enums;

namespace CompanyTree.UI
{
    public class CliController
    {
        private readonly CliView _view;
        private readonly ICompanyTreeService _companyTreeService;

        public CliController(ICompanyTreeService companyTreeService, CliView cliView)
        {
            _companyTreeService = companyTreeService;
            _view = cliView;
        }
        
        public void ShowMenu()
        {
            Employee root = _companyTreeService.GetRoot();
            MainMenu userVariant = (MainMenu)(_view.Main());
            List<String> employees;
            switch (userVariant)
            {
                case MainMenu.AddEmployee:
                    ShowAddEmployeeMenu(root);
                    break;
                case MainMenu.SelectFindWithMaxSalary:
                    ShowEmployeeWithMaxSalary(root);
                    break;
                case MainMenu.SelectFindWithHigherSalary:
                    ShowEmployeeWithHigherSalary(root);
                    break;
                case MainMenu.SelectFindWithPosition:
                    ShowEmployeeWithPosition(root);
                    break;
                case MainMenu.Exit:
                    Environment.Exit(0);
                    break;
            }
            ShowMenu();
        }

        private void ShowAddEmployeeMenu(Employee root)
        {
            List<String> employees = _companyTreeService.GetEmployeesWithPosition(root, Position.Director).Select(x => x.Name).ToList();
            
            int position = _view.SelectPosition();
            string name = _view.PrintNameDialog();
            int salary = _view.PrintSalaryDialog();
            //int employeeToAdd = _view.SelectByEmployeeList();
        }
        
        public void ShowEmployeeWithMaxSalary(Employee root)
        {
            List<String> employees = _companyTreeService.GetEmployeesWithMaxSalary(root).Select(x => x.Name).ToList();
            _view.ShowEmployeeList(employees);
        }
        
        public void ShowEmployeeWithHigherSalary(Employee root)
        {
            int salary = _view.PrintSalaryDialog();
            List<String> employees = _companyTreeService.GetEmployeesWithHigherSalary(root, salary).Select(x => x.Name).ToList();
            _view.ShowEmployeeList(employees);
        }
        
        public void ShowEmployeeWithPosition(Employee root)
        {
            Position position = (Position)_view.SelectPosition();
            List<String> employees = _companyTreeService.GetEmployeesWithPosition(root, position).Select(x => x.Name).ToList();
            _view.ShowEmployeeList(employees);
        }
    }
}