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
                new Employee() { Id = 1, Name = "Mary", Department = Dept.Hr, Email = "Mary@gmail.com" },
                new Employee() { Id = 2, Name = "John", Department = Dept.It, Email = "John@gmail.com" },
                new Employee() { Id = 3, Name = "Sam", Department = Dept.It, Email = "Sam@gmail.com" }
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

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(x => x.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }

        public Employee Update(Employee employeeChange)
        {
            Employee employee = _employeeList.FirstOrDefault(x => x.Id == employeeChange.Id);
            if (employee != null)
            {
                employee.Name = employeeChange.Name;
                employee.Email = employeeChange.Email;
                employee.Department = employeeChange.Department;
            }
            return employee;
        }

        public Employee Delete(int id)
        {
           Employee employee = _employeeList.FirstOrDefault(x => x.Id == id);
            if (employee != null)
            {
                _employeeList.Remove(employee);
            }
            return employee;
        }
    }
}
