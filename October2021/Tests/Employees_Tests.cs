using NUnit.Framework;
using October2021.Pages;
using October2021.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace October2021.Tests
{
    [TestFixture]
    [Parallelizable]
    class Employees_Tests : CommonDriver
    {
        [Test, Order(1), Description("Check if user is able to create an Employee record with valid data")]
        public void CreateEmployeeTest()
        {
            HomePage homePageObj = new HomePage();
            homePageObj.GoToEmployee(driver);

            // Employee page object initialization and definition
            EmployeePage employeePageObj = new EmployeePage();
            employeePageObj.CreateEmployee(driver);
        }

        [Test, Order(2), Description("Check if user is able to edit an existing Employee record")]
        public void EditEmployeeTest()
        {
            HomePage homePageObj = new HomePage();
            homePageObj.GoToEmployee(driver);

            // Edit Employee
            EmployeePage employeePageObj = new EmployeePage();
            employeePageObj.EditEmployee(driver);
            
        }

        [Test, Order(3), Description("Check if user is able to delete an Employee record")]
        public void DeleteEmployeeTest()
        {
            HomePage homePageObj = new HomePage();
            homePageObj.GoToEmployee(driver);

            // Delete Employee
            EmployeePage employeePageObj = new EmployeePage();
            employeePageObj.DeleteEmployee(driver);
            
        }
    }
}
