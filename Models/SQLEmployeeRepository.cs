using CursoIndio.Controllers.Models;
using System.Collections.Generic;

namespace CursoIndio.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public SQLEmployeeRepository(AppDbContext context)
        {
            _context = context;
        }
        public Employee Add(Employee employee)
        {
           _context.employees.Add(employee);
           _context.SaveChanges();
           return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = _context.employees.Find(id);
            if(employee != null)
            {
                _context.Remove(employee);
                _context.SaveChanges();
            }
            return employee; 
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _context.employees;
        }

        public Employee GetEmployee(int id)
        {
            return _context.employees.Find(id);
        }

        public Employee Update(Employee employeeChanges)
        {
            var employee = _context.employees.Attach(employeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return employeeChanges;
        }
    }
}
