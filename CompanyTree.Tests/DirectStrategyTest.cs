using System;
using System.Collections.Generic;
using System.Linq;
using CompanyTree.BLL.Implementation.CompanyStructureDisplay;
using CompanyTree.Models.Abstractions;
using CompanyTree.Models.Employees;
using CompanyTree.Models.Managers;
using Moq;
using Xunit;

namespace CompanyTree.Tests
{
    public class DirectStrategyTest
    {
        [Fact]
        public void RightOrderTest()
        {
            //Arrange
            Mock<Employee> employeeX = new Moq.Mock<Employee>("employeeX", 1000, Position.EmployeeX); 
            employeeX.Setup(e => e.IsComposite()).Returns(false);
            Mock<Employee> employeeY = new Moq.Mock<Employee>("employeeY", 1000, Position.EmployeeY); 
            employeeY.Setup(e => e.IsComposite()).Returns(false);
            Mock<Employee> employeeA = new Moq.Mock<Employee>("employeeA", 1000, Position.EmployeeA);
            employeeA.Setup(e => e.IsComposite()).Returns(false);
            Mock<Employee> employeeB = new Moq.Mock<Employee>("employeeB", 1000, Position.EmployeeB);
            employeeB.Setup(e => e.IsComposite()).Returns(false);
            Mock<Employee> supplyManager = new Moq.Mock<Employee>("SupplyManager", 1000, Position.SupplyManager);
            supplyManager.Setup(e => e.IsComposite()).Returns(true);
            supplyManager.Setup(e => e.GetChildren()).Returns(new List<Employee>( new[] { employeeX.Object, employeeY.Object } ));
            Mock<Employee> salesManager = new Moq.Mock<Employee>("SalesManager", 1000, Position.SalesManager);
            salesManager.Setup(e => e.IsComposite()).Returns(true);
            salesManager.Setup(e => e.GetChildren()).Returns(new List<Employee>( new[] { employeeA.Object, employeeB.Object } ));
            Mock<Employee> director = new Moq.Mock<Employee>("Director", 1000, Position.Director);
            director.Setup(e => e.IsComposite()).Returns(true);
            director.Setup(e => e.GetChildren()).Returns(new List<Employee>( new[]{ supplyManager.Object, salesManager.Object }));
            
            List<Employee> expectedResult = new List<Employee>( 
                new[] { director.Object, supplyManager.Object, employeeX.Object, employeeY.Object,
                    salesManager.Object, employeeA.Object, employeeB.Object }
            );
            
            CompanyStructureDirectStrategy strategy = new CompanyStructureDirectStrategy();
            
            //Act
            List<Employee> result = strategy.GetStructure(director.Object).ToList();
            
            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}