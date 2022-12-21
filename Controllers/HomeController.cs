using CursoIndio.Controllers.Models;
using CursoIndio.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace CursoIndio.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHostingEnvironment _hostingEnvironment;
		private readonly ILogger logger;

        public HomeController(IEmployeeRepository employeeRepository,
                              IHostingEnvironment hostingEnvironment,
							  ILogger<HomeController> logger)
        {
            _employeeRepository = employeeRepository;
            _hostingEnvironment = hostingEnvironment;
			this.logger = logger;
        }
        [AllowAnonymous]
        [Route("")]
        public ViewResult Index()
        {
            var model = _employeeRepository.GetAllEmployee();
            return View(model);
        }
        [AllowAnonymous]
        public ViewResult Details(int? id)
        {
            logger.LogTrace("Trace Log");
            logger.LogDebug("Debug Log");
            logger.LogInformation("Information Log");
            logger.LogWarning("Warning Log");
            logger.LogError("Error Log");
            logger.LogCritical("Critical Log");

            Employee employee = _employeeRepository.GetEmployee(id.Value);

			if(employee == null)
			{
				Response.StatusCode = 404;
				return View("EmployeeNotFound",id.Value);
			}

			HomeDetailsViewModel homeDetailsViewModel = new()
			{
				Employee = employee,
				PageTitle = "Employee Details"
            };
            return View(homeDetailsViewModel);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
		[HttpPost]
		public IActionResult Create(EmployeeCreateViewModel model)
		{
			if (ModelState.IsValid)
			{
				string uniqueFileName = null;

				// If the Photos property on the incoming model object is not null and if count > 0,
				// then the user has selected at least one file to upload

				if (model.Photos != null && model.Photos.Count > 0)
				{
					// Loop thru each selected file
					foreach (IFormFile photo in model.Photos)
					{
                        // The file must be uploaded to the images folder in wwwroot
                        // To get the path of the wwwroot folder we are using the injected
                        // IHostingEnvironment service provided by ASP.NET Core
						string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
						// To make sure the file name is unique we are appending a new
						// GUID value and and an underscore to the file name
						uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
						string filePath = Path.Combine(uploadsFolder, uniqueFileName);
						// Use CopyTo() method provided by IFormFile interface to
						// copy the file to wwwroot/images folder
						photo.CopyTo(new FileStream(filePath, FileMode.Create));
					}
				}

				Employee newEmployee = new()
				{
					Name = model.Name,
					Email = model.Email,
					Department = model.Department,
					PhotoPath = uniqueFileName
				};

				_employeeRepository.Add(newEmployee);
				return RedirectToAction("details", new { id = newEmployee.Id });
			}

			return View();
		}
    }
}
