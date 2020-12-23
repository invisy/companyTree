using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CompanyTree.Models.Abstractions;
using CompanyTree.Models.Managers;
using Moq;
using Xunit;

namespace CompanyTree.Tests
{
    public class EmployeeCompositeTest
    {
        [Fact]
        public void AddElement_Employee()
        {
            //Arrange
            Mock<Employee> managerStub = new Moq.Mock<Employee>("SupplyManager", 1000, Position.SupplyManager);
            managerStub.Setup(e => e.IsComposite()).Returns(true);
            List<Employee> expectedResult = new List<Employee>();
            expectedResult.Add(managerStub.Object);
            Director director = new Director("Director1", 1000);
            //Act
            director.Add(managerStub.Object);
            //Assert
            Assert.Equal(director.GetChildren(), expectedResult);
        }
        
        [Fact]
        public void AddElement_Employee_ThrowsNullReferenceException()
        {
            //Arrange
            Director director = new Director("Director1", 1000);
            //Act
            var ex = Assert.Throws<ArgumentNullException>(() => director.Add(null));
            //Assert
            Assert.Equal("Can`t add null employee", ex.ParamName);
        }
    }
}