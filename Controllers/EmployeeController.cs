using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;

namespace WebAppDemoNLayer.Controllers
{
    public class EmployeeController : Controller
    {
        public EmployeeService EmployeeService { get; }

        public EmployeeController(EmployeeService employeeService)
        {
            EmployeeService = employeeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var employees = EmployeeService.GetAll();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Add");
        }

        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            EmployeeService.AddEmployee(employee);
            return View(nameof(Index),EmployeeService.GetAll());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var emp = EmployeeService.GetEmployee(id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            EmployeeService.UpdateEmployee(employee);
            return View(nameof(Index), EmployeeService.GetAll());
        }
        public IActionResult Delete(int id)
        {
            EmployeeService.RemoveEmployee(id);
            return RedirectToAction(nameof(Index), EmployeeService.GetAll());
        }
        public IActionResult Details(int id)
        {
            var emp = EmployeeService.GetEmployee(id);
            return View(emp);
        }
    }
}
