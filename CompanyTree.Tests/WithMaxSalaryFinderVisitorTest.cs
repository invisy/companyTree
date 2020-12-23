using System;
using System.Collections.Generic;
using System.Linq;
using CompanyTree.BLL.Implementation.CompanyStructureDisplay;
using CompanyTree.BLL.Implementation.Visitors;
using CompanyTree.Models.Abstractions;
using CompanyTree.Models.Employees;
using CompanyTree.Models.Managers;
using Moq;
using Xunit;

namespace CompanyTree.Tests
{
    public class WithMaxSalaryFinderVisitorTest
    {
        private Mock<EmployeeX> employeeX;
        private Mock<EmployeeY> employeeY;
        private Mock<EmployeeX> employeeX2;
        private Mock<EmployeeY> employeeY2;
        private Mock<EmployeeA> employeeA;
        private Mock<EmployeeB> employeeB;
        private Mock<SupplyManager> supplyManager;
        private Mock<SalesManager> salesManager;
        private Mock<Director> director;
        
        public WithMaxSalaryFinderVisitorTest()
        {
            employeeX2 = new Moq.Mock<EmployeeX>("employeeX", 150, null);
            employeeX2.Setup(e => e.IsComposite()).Returns(false);
            employeeX2.Setup(e => e.Accept(It.IsAny<IVisitor>())).Callback<IVisitor>(v => v.Visit(employeeX2.Object));
            
            employeeY2 = new Moq.Mock<EmployeeY>("employeeY", 950, null);
            employeeY2.Setup(e => e.IsComposite()).Returns(false);
            employeeY2.Setup(e => e.Accept(It.IsAny<IVisitor>())).Callback<IVisitor>(v => v.Visit(employeeY2.Object));
            
            employeeX = new Moq.Mock<EmployeeX>("employeeX", 100, null);
            employeeX.Setup(e => e.IsComposite()).Returns(false);
            employeeX.Setup(e => e.Accept(It.IsAny<IVisitor>())).Callback<IVisitor>(v => v.Visit(employeeX.Object));
            
            employeeY = new Moq.Mock<EmployeeY>("employeeY", 1000, null);
            employeeY.Setup(e => e.IsComposite()).Returns(false);
            employeeY.Setup(e => e.Accept(It.IsAny<IVisitor>())).Callback<IVisitor>(v => v.Visit(employeeY.Object));
            
            employeeA = new Moq.Mock<EmployeeA>("employeeA", 1200, null);
            employeeA.Setup(e => e.IsComposite()).Returns(false);
            employeeA.Setup(e => e.Accept(It.IsAny<IVisitor>())).Callback<IVisitor>(v => v.Visit(employeeA.Object));
            
            employeeB = new Moq.Mock<EmployeeB>("employeeB", 800, null);
            employeeB.Setup(e => e.IsComposite()).Returns(false);
            employeeB.Setup(e => e.Accept(It.IsAny<IVisitor>())).Callback<IVisitor>(v => v.Visit(employeeB.Object));
            
            supplyManager = new Moq.Mock<SupplyManager>("SupplyManager", 1200, null);
            supplyManager.Setup(e => e.IsComposite()).Returns(true);
            supplyManager.Setup(e => e.GetChildren()).Returns(new List<Employee>( new Employee[] { employeeX.Object, employeeY.Object, employeeX2.Object, employeeY2.Object } ));
            supplyManager.Setup(e => e.Accept(It.IsAny<IVisitor>())).Callback<IVisitor>(v => v.Visit(supplyManager.Object));
            
            salesManager = new Moq.Mock<SalesManager>("SalesManager", 200, null);
            salesManager.Setup(e => e.IsComposite()).Returns(true);
            salesManager.Setup(e => e.GetChildren()).Returns(new List<Employee>( new Employee[] { employeeA.Object, employeeB.Object } ));
            salesManager.Setup(e => e.Accept(It.IsAny<IVisitor>())).Callback<IVisitor>(v => v.Visit(salesManager.Object));

            director = new Moq.Mock<Director>("Director", 300);
            director.Setup(e => e.IsComposite()).Returns(true);
            director.Setup(e => e.GetChildren()).Returns(new List<Employee>( new Employee[]{ supplyManager.Object, salesManager.Object }));
            director.Setup(e => e.Accept(It.IsAny<IVisitor>())).Callback<IVisitor>(v => v.Visit(director.Object));
        }
        
        [Fact]
        public void VisitedAll()
        {
            //Arrange
            WithMaxSalaryFinderVisitor visitor = new WithMaxSalaryFinderVisitor();

            //Act
            director.Object.Accept(visitor);
            
            //Assert
            director.Verify(x => x.Accept(It.IsAny<IVisitor>()), Times.Once());
            salesManager.Verify(x => x.Accept(It.IsAny<IVisitor>()), Times.Once());
            salesManager.Verify(x => x.Accept(It.IsAny<IVisitor>()), Times.Once());
            supplyManager.Verify(x => x.Accept(It.IsAny<IVisitor>()), Times.Once());
            employeeA.Verify(x => x.Accept(It.IsAny<IVisitor>()), Times.Once());
            employeeB.Verify(x => x.Accept(It.IsAny<IVisitor>()), Times.Once());
            employeeX.Verify(x => x.Accept(It.IsAny<IVisitor>()), Times.Once());
            employeeY.Verify(x => x.Accept(It.IsAny<IVisitor>()), Times.Once());
        }

        [Fact]
        public void GetEmployees_ReturnsEmployeeListWithMaxSalary()
        {
            //Arrange
            WithMaxSalaryFinderVisitor visitor = new WithMaxSalaryFinderVisitor();
            List<Employee> expectedResult = new List<Employee>(new Employee[] { supplyManager.Object, employeeA.Object });

            //Act
            director.Object.Accept(visitor);
            List<Employee> result = visitor.GetEmployees().ToList();
            
            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}