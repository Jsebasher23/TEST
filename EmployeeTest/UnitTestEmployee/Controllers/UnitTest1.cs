using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeTest.Controllers;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeTest.Models;

namespace EmployeeIndex.Tests
{
    [TestClass()]
    public class UnitTest1
    {
        [TestMethod()]
        public async Task EmployeeIndexTest()
        {
            var testEmployee = new EmployeeController();
            var res = await testEmployee.Index() as ViewResult;
            Assert.AreEqual("Index", res.ViewName);
        }
        [TestMethod()]
        public async Task EmployeeDetailsTest()
        {
            var testEmployee = new EmployeeController();
            var res = await testEmployee.Details("1") as ViewResult;
            Assert.AreEqual("Details", res.ViewName);
        }
        [TestMethod]
        public void EmployeeCalculatedTest()
        {
            var testEmployee = new EmployeeController();
            var testDetails = GetTestEmployee();
            var res = testEmployee.CalculatedSalary(testDetails,null) as List<Employee>;
            Assert.AreEqual(testDetails.Count, res.Count);
        }

        private List<Employee> GetTestEmployee()
        {
            var testProducts = new List<Employee>();
            testProducts.Add(new Employee
            {
                Id = 1,
                Name = "Juan",
                ContractTypeName = "HourlySalaryEmployee",
                RoleName = "Administrator",
                HourlySalary = 60000,
                MonthlySalary = 80000
            });
            testProducts.Add(new Employee
            {
                Id = 2,
                Name = "Sebastian",
                ContractTypeName = "MonthlySalaryEmployee",
                RoleName = "Contractor",
                HourlySalary = 60000,
                MonthlySalary = 80000
            });

            return testProducts;
        }
    }
}