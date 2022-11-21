using System.Collections.Generic;
using System.Linq;

namespace CursoIndio.Controllers.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "Mary", Department = "HR", Email = "Mary@gmail.com" },
                new Employee() { Id = 2, Name = "John", Department = "IT", Email = "John@gmail.com" },
                new Employee() { Id = 3, Name = "Sam", Department = "IT", Email = "Sam@gmail.com" }
            };
        }
        public Employee GetEmployee(int id)
        {
            return _employeeList.Find(x => x.Id == id);
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList;
        }
    }
}
