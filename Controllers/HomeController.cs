using CursoIndio.Controllers.Models;
using CursoIndio.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CursoIndio.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [Route("")]
        public ViewResult Index()
        {
            var model = _employeeRepository.GetAllEmployee();
            return View(model);
        }
        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new()
            {
                Employee = _employeeRepository.GetEmployee(id??1),
                PageTitle = "Employee Details"
            };
            return View(homeDetailsViewModel);
        }
    }
}
