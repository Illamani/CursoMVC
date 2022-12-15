using CursoIndio.Controllers.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace CursoIndio.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger logger;
        public SQLEmployeeRepository(AppDbContext context, ILogger<SQLEmployeeRepository> logger)
        {
            _context = context;
            this.logger = logger;
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
            logger.LogTrace("Trace Log");
            logger.LogDebug("Debug Log");
            logger.LogInformation("Information Log");
            logger.LogWarning("Warning Log");
            logger.LogError("Error Log");
            logger.LogCritical("Critical Log");

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
