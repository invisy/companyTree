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
        private readonly ICompanyTreeFinderService _companyTreeFinderService;
        private readonly ICompanyTreeStructuringService _companyTreeStructuringService;
        private readonly ILoaderService _loaderService;
        private Employee _root;
        
        public CliController(ICompanyTreeFinderService companyTreeFinderService, 
            ICompanyTreeStructuringService companyTreeStructuringService, ILoaderService loaderService, CliView cliView)
        {
            _companyTreeFinderService = companyTreeFinderService;
            _companyTreeStructuringService = companyTreeStructuringService;
            _loaderService = loaderService;
            _view = cliView;
            _root = _loaderService.LoadData();
        }
        
        public void ShowMenu()
        {
            Employee root = null;
            MainMenu userVariant = (MainMenu)(_view.Main());
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
            List<String> employees = _companyTreeFinderService.GetEmployeesWithPosition(root, Position.Director).Select(x => x.Name).ToList();
            
            int position = _view.SelectPosition();
            string name = _view.PrintNameDialog();
            int salary = _view.PrintSalaryDialog();
            //int employeeToAdd = _view.SelectByEmployeeList();
        }
        
        public void ShowEmployeeWithMaxSalary(Employee root)
        {
            List<String> employees = _companyTreeFinderService.GetEmployeesWithMaxSalary(root).Select(x => x.Name).ToList();
            _view.ShowEmployeeList(employees);
        }
        
        public void ShowEmployeeWithHigherSalary(Employee root)
        {
            int salary = _view.PrintSalaryDialog();
            List<String> employees = _companyTreeFinderService.GetEmployeesWithHigherSalary(root, salary).Select(x => x.Name).ToList();
            _view.ShowEmployeeList(employees);
        }
        
        public void ShowEmployeeWithPosition(Employee root)
        {
            Position position = (Position)_view.SelectPosition();
            List<String> employees = _companyTreeFinderService.GetEmployeesWithPosition(root, position).Select(x => x.Name).ToList();
            _view.ShowEmployeeList(employees);
        }
    }
}