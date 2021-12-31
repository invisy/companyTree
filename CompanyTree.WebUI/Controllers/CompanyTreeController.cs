using CompanyTree.BLL.Abstraction.Services;
using CompanyTree.Models.Abstractions;
using CompanyTree.Models.Employees;
using CompanyTree.Models.Managers;
using CompanyTree.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyTree.WebUI.Controllers
{
    public class CompanyTreeController : Controller
    {
        ICompanyTreeFinderService _finderService;
        ICompanyTreeStructuringService _structuringService;
        ILoaderService _loaderService;
        Employee _root;

        public CompanyTreeController(ICompanyTreeFinderService finderService, ICompanyTreeStructuringService structuringService,
            ILoaderService loaderService)
        {
            _finderService = finderService;
            _structuringService = structuringService;
            _loaderService = loaderService;
            _root = _loaderService.getRoot();
        }

        // GET
        public IActionResult Index()
        {
            return Redirect("/CompanyTree/DirectOrder");
        }

        private IActionResult Index(IEnumerable<Employee> employee)
        {
            return View(employee);
        }

        public IActionResult DirectOrder()
        {
            if (_root == null)
                return View("Index", new List<Employee>());

            IEnumerable<Employee> employees = _structuringService.GetDirectCompanyStructure(_root);
            return View("Index", employees);
        }

        public IActionResult ByPositionOrder()
        {
            if (_root == null)
                return View("Index", new List<Employee>());

            IEnumerable<Employee> employees = _structuringService.GetByPositionCompanyStructure(_root);
            return View("Index", employees);
        }

        public IActionResult FindWithMaxSalary()
        {
            if (_root == null)
                return View("Index", new List<Employee>());

            IEnumerable<Employee> employees = _finderService.GetEmployeesWithMaxSalary(_root);
            return View("Index", employees);
        }

        public IActionResult FindWithHigherSalary()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult FindWithHigherSalary(FindWithHigherSalaryVM salaryVM)
        {
            if (_root == null)
                return View("Index", new List<Employee>());

            IEnumerable<Employee> employees = _finderService.GetEmployeesWithHigherSalary(_root, salaryVM.Salary);
            return View("Index", employees);
        }

        public IActionResult FindWithPosition()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FindWithPosition(FindWithPositionVM findByPositionVM)
        {
            if (_root == null)
                return View("Index", new List<Employee>());

            IEnumerable<Employee> employees = _finderService.GetEmployeesWithPosition(_root, findByPositionVM.Position);
            return View("Index", employees);
        }

        public IActionResult AddEmployee()
        {

            AddEmployeeVM vm = new AddEmployeeVM();
            if (_root != null)
                vm.Parent = _structuringService.GetDirectCompanyStructure(_root);
            else
                vm.Parent = new List<Employee>();
            vm.Supervisor = vm.Parent;
            return View(vm);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeVM vm)
        {
            Employee newEmployee;

            if (vm.SelectedParentId == 0)
            {
                _loaderService.setRoot(new Director(vm.Name, vm.Salary));
                return Redirect("/CompanyTree/DirectOrder");
            }

                Employee parent = _finderService.GetEmployeesWithId(_root, vm.SelectedParentId).FirstOrDefault();
            Employee supervisor = _finderService.GetEmployeesWithId(_root, vm.SelectedSupervisorId).FirstOrDefault();

            switch (vm.Position)
            {
                case Position.Director:
                    newEmployee = new Director(vm.Name, vm.Salary);
                    break;
                case Position.SupplyManager:
                    newEmployee = new SupplyManager(vm.Name, vm.Salary, supervisor);
                    break;
                case Position.SalesManager:
                    newEmployee = new SalesManager(vm.Name, vm.Salary, supervisor);
                    break;
                case Position.EmployeeA:
                    newEmployee = new EmployeeA(vm.Name, vm.Salary, supervisor);
                    break;
                case Position.EmployeeB:
                    newEmployee = new EmployeeB(vm.Name, vm.Salary, supervisor);
                    break;
                case Position.EmployeeX:
                    newEmployee = new EmployeeX(vm.Name, vm.Salary, supervisor);
                    break;
                case Position.EmployeeY:
                    newEmployee = new EmployeeY(vm.Name, vm.Salary, supervisor);
                    break;
                default:
                    newEmployee = new Director(vm.Name, vm.Salary);
                    break;
            }

            if (parent.IsComposite())
                parent.Add(newEmployee);

            return Redirect("/CompanyTree/DirectOrder");
        }

        public IActionResult Load()
        {
            _loaderService.LoadData();
            return Redirect("/CompanyTree/DirectOrder");
        }

        public IActionResult Save()
        {
            _loaderService.SaveData();
            return Redirect("/CompanyTree/DirectOrder");
        }
    }
}