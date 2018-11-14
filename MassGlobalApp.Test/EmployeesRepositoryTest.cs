using MasGlobalApp.Api.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MassGlobalApp.Test
{
    [TestClass]
    public class EmployeesRepositoryTest
    {

        [TestMethod]
        public void TestGetAllEmployees()
        {          

            var mockEmps = new List<Employee>();

            mockEmps.Add(new Employee
            { Id = 1, Name = "Pedro", ContractTypeName = "HourlySalaryEmployee", RoleId = 1, RoleName = "Contractor", RoleDescription = "N/A", HourlySalary = 30000, MonthlySalary = 5000 });

            mockEmps.Add(new Employee
            { Id = 5, Name = "Juan", ContractTypeName = "MonthlySalaryEmployee", RoleId = 2, RoleName = "Administrator", RoleDescription = "N/A", HourlySalary = 80000, MonthlySalary = 1000 });

            mockEmps.Add(new Employee
            { Id = 10, Name = "Camila", ContractTypeName = "MonthlySalaryEmployee", RoleId = 1, RoleName = "Contractor", RoleDescription = "N/A", HourlySalary = 54000, MonthlySalary = 7000 });

            var employeeRepositoryMock = TestInitializer.MockEmployeeRepository;

            employeeRepositoryMock.Setup
                  (x => x.GetEmployees()).Returns(Task.FromResult<IEnumerable<IEmployee>>(mockEmps));

            var response = TestInitializer.TestHttpClient.GetAsync("api/Employees").Result;

            var resp = response.Content.ReadAsStringAsync().Result;
            var responseData = JsonConvert.DeserializeObject<List<Employee>>(resp);
            Assert.AreEqual(3, responseData.Count);
            Assert.AreEqual(mockEmps[0].Id, responseData[0].Id);
            Assert.AreEqual(mockEmps[1].Id, responseData[1].Id);
            Assert.AreEqual(mockEmps[2].Id, responseData[2].Id);
        }

        [TestMethod]
        public void TestGetEmployeeWithId10()
        {

            var mockEmps = new Employee           
            
            { Id = 10, Name = "Camila", ContractTypeName = "MonthlySalaryEmployee", RoleId = 1, RoleName = "Contractor", RoleDescription = "N/A", HourlySalary = 54000, MonthlySalary = 7000 };

            var employeeRepositoryMock = TestInitializer.MockEmployeeRepository;

            employeeRepositoryMock.Setup
                  (x => x.GetEmployee(10)).Returns(Task.FromResult<IEmployee>(mockEmps));

            var response = TestInitializer.TestHttpClient.GetAsync("api/Employees/10").Result;

            var resp = response.Content.ReadAsStringAsync().Result;
            var responseData = JsonConvert.DeserializeObject<Employee>(resp);            
            Assert.AreEqual(mockEmps.Id, responseData.Id);           
        }

        [TestMethod]
        public void TestNotFoundEmployeeWithId20()
        {
            var mockEmps = new Employee();           

            var employeeRepositoryMock = TestInitializer.MockEmployeeRepository;

            employeeRepositoryMock.Setup
                  (x => x.GetEmployee(10)).Returns(Task.FromResult<IEmployee>(mockEmps));

            var response = TestInitializer.TestHttpClient.GetAsync("api/Employees/20").Result;

            var resp = response.Content.ReadAsStringAsync().Result;
            var responseData = JsonConvert.DeserializeObject<Employee>(resp);
            Assert.AreEqual(null, responseData);
        }
    }
}
