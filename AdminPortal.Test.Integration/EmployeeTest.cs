using AdminPortal.Data.Repository;
using AdminPortal.Test.Integration.Helper;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace Tests
{
    class EmployeeTest
    {
        EmployeeRepository employeeRepository;

        [SetUp]
        public void Setup()
        {
            var connectionString = TestHelper.GetDevConnection();

            // 1. Reset Tables with Test Data
            TestHelper.ResetDb(connectionString);

            // 2. Initialize Repository
            employeeRepository = new EmployeeRepository(connectionString);
        }

        [Test]
        public void GetEmployeeByIdTest()
        {
            var employee = employeeRepository.GetEntityById(1);

            Assert.IsNotNull(employee);
            Assert.AreEqual(1, employee.Id);
            Assert.AreEqual("John", employee.FirstName);
            Assert.AreEqual("Doe", employee.LastName);
            Assert.AreEqual("1234", employee.UserId);
            Assert.AreEqual(1, employee.DepartmentId);
        }

        [Test]
        public async Task GetEmployeeByIdAsyncTest()
        {
            var employee = await employeeRepository.GetEntityByIdAsync(1);

            Assert.IsNotNull(employee);
            Assert.AreEqual(1, employee.Id);
            Assert.AreEqual("John", employee.FirstName);
            Assert.AreEqual("Doe", employee.LastName);
            Assert.AreEqual("1234", employee.UserId);
            Assert.AreEqual(1, employee.DepartmentId);
        }

        [Test]
        public void GetEmployeeSkillsByIdTest()
        {
            var employeeSkills = employeeRepository.GetSkillsById(1);

            Assert.IsNotNull(employeeSkills);
            Assert.AreEqual(1, employeeSkills.Count());
            Assert.AreEqual(1, employeeSkills.First().Id);
            Assert.AreEqual("Cash", employeeSkills.First().Name);
        }

        [Test]
        public void GetEmployeeByUserIdTest()
        {
            var employee = employeeRepository.GetEmployeeByUserId("1234");

            Assert.IsNotNull(employee);
            Assert.AreEqual(1, employee.Id);
            Assert.AreEqual("John", employee.FirstName);
            Assert.AreEqual("Doe", employee.LastName);
            Assert.AreEqual("1234", employee.UserId);
            Assert.AreEqual(1, employee.DepartmentId);
        }
    }
}
