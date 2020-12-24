using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CompanyTree.BLL.Abstraction.Services;
using CompanyTree.Models;
using CompanyTree.Models.Abstractions;
using CompanyTree.Models.Employees;
using CompanyTree.Models.Managers;
using CompanyTree.UI.Enums;
using CompanyTree.UI.Exceptions;

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
            _loaderService.LoadData();
            _root = _loaderService.getRoot();
        }
        
        public void ShowMenu()
        {
            while (true)
            {
                try
                {
                    _view.Main();
                    var mainMenuVariantsCount = Enum.GetNames(typeof(MainMenu)).Length;
                    MainMenu userVariant =
                        (MainMenu) Validator.ValidateNumber(Console.ReadLine(), 0, mainMenuVariantsCount);
                    switch (userVariant)
                    {
                        case MainMenu.AddEmployee:
                            ShowAddEmployeeMenu();
                            break;
                        case MainMenu.ShowListOfEmployees:
                            ShowSelectOrderMenu();
                            break;
                        case MainMenu.SelectFindWithMaxSalary:
                            ShowEmployeeWithMaxSalary();
                            break;
                        case MainMenu.SelectFindWithHigherSalary:
                            ShowEmployeeWithHigherSalary();
                            break;
                        case MainMenu.SelectFindWithPosition:
                            ShowEmployeeWithPosition();
                            break;
                        case MainMenu.Exit:
                            Environment.Exit(0);
                            break;
                    }
                }
                catch (InvalidInputException e)
                {
                    Console.WriteLine("Invalid input data: " + e.Message.ToString());
                }
                catch (NoNullAllowedException e)
                {
                    if (e.Message == "Employee root can`t be null")
                    {
                        Console.WriteLine("Employee root is clean");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unknown error");
                }
            }
        }

        private void ShowSelectOrderMenu()
        {
            var selectViewOrderMenuVariantsCount = Enum.GetNames(typeof(SelectViewOrderMenu)).Length;
            _view.SelectViewOrderMenu();
            SelectViewOrderMenu userVariant = (SelectViewOrderMenu)Validator.ValidateNumber(Console.ReadLine(), 0, selectViewOrderMenuVariantsCount);
            switch ((SelectViewOrderMenu)userVariant)
            {
                case SelectViewOrderMenu.DirectOrder:
                    DisplayEmployeeList(_companyTreeStructuringService.GetDirectCompanyStructure(_root));
                    break;
                case SelectViewOrderMenu.ByPosition:
                    DisplayEmployeeList(_companyTreeStructuringService.GetByPositionCompanyStructure(_root));
                    break;
                case SelectViewOrderMenu.Menu:
                    ShowMenu();
                    break;
            }
        }
        
        private void ShowAddEmployeeMenu()
        {
            Employee newEmployee;
            Employee parent = null;
            Employee supervisor = null;
            _view.PrintNameDialog();
            string name = Validator.ValidateText(Console.ReadLine(), 1, Int32.MaxValue);
            _view.PrintSalaryDialog();
            int salary = Validator.ValidateNumber(Console.ReadLine(), 0, Int32.MaxValue);
            if (_root != null)
            {
                Console.WriteLine("Parent selection");
                parent = DisplayEmployeeSelectList(_companyTreeStructuringService.GetDirectCompanyStructure(_root));
                Console.WriteLine("Supervisor selection");
                supervisor = DisplayEmployeeSelectList(_companyTreeStructuringService.GetDirectCompanyStructure(_root));
            }

            _view.SelectPosition();
            var selectPositionVariantsCount = Enum.GetNames(typeof(Position)).Length;
            Position position = (Position)Validator.ValidateNumber(Console.ReadLine(), 1, selectPositionVariantsCount);
            
            switch (position-1)
            {
                case Position.Director:
                    newEmployee = new Director(name, salary);
                    break;
                case Position.SupplyManager:
                    newEmployee = new SupplyManager(name, salary, supervisor);
                    break;
                case Position.SalesManager:
                    newEmployee = new SalesManager(name, salary, supervisor);
                    break;
                case Position.EmployeeA:
                    newEmployee = new EmployeeA(name, salary, supervisor);
                    break;
                case Position.EmployeeB:
                    newEmployee = new EmployeeB(name, salary, supervisor);
                    break;
                case Position.EmployeeX:
                    newEmployee = new EmployeeX(name, salary, supervisor);
                    break;
                case Position.EmployeeY:
                    newEmployee = new EmployeeY(name, salary, supervisor);
                    break;
                default:
                    newEmployee = new Director(name, salary);
                    break;
            }

            if (parent != null)
            {
                if (parent.IsComposite())
                    parent.Add(newEmployee);
                else
                {
                    Console.WriteLine("You can`t add employee to simple employee!");
                }
            }
            else 
                _root = newEmployee;
        }
        
        private void ShowEmployeeWithMaxSalary()
        {
            DisplayEmployeeList(_companyTreeFinderService.GetEmployeesWithMaxSalary(_root));
        }
        
        private void ShowEmployeeWithHigherSalary()
        {
            _view.PrintSalaryDialog();
            int salary = Validator.ValidateNumber(Console.ReadLine(), 0, Int32.MaxValue);
            DisplayEmployeeList(_companyTreeFinderService.GetEmployeesWithHigherSalary(_root, salary));
        }
        
        private void ShowEmployeeWithPosition()
        {
            _view.SelectPosition();
            var selectPositionVariantsCount = Enum.GetNames(typeof(Position)).Length;
            Position position = (Position)Validator.ValidateNumber(Console.ReadLine(), 1, selectPositionVariantsCount)-1;
            List<String> employees = _companyTreeFinderService.GetEmployeesWithPosition(_root, position).Select(x => x.Name).ToList();
            _view.ShowEmployeeList(employees);
        }

        private void DisplayEmployeeList(IEnumerable<Employee> employeeList)
        {
            _view.ShowEmployeeList(employeeList.Select(x =>
                x.Name + " (position: " + x.Position + "; salary: " + x.Salary + ")").ToList());
        }
        
        private Employee DisplayEmployeeSelectList(IEnumerable<Employee> employeeEnumerable)
        {
            List<Employee> employeeList = employeeEnumerable.ToList();
            _view.SelectByEmployeeList(employeeList.Select(x => 
                x.Name + " (position: " + x.Position + "; salary: " + x.Salary + ")").ToList());
            int id = Validator.ValidateNumber(Console.ReadLine(), 0, employeeList.Count());
            if (id == 0)
                return null;
            return employeeList.ToList()[id-1];
        }
    }
}