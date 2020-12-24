using CompanyTree.BLL.Abstraction.Services;
using CompanyTree.Models.Abstractions;
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