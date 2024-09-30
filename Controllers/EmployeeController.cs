using Crude_Operation1.WEB.Interface;
using Crude_Operation1.WEB.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crude_Operation1.WEB.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeManager _employeeManager;
        public EmployeeController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }
        public IActionResult Index()
        {
            var employees = _employeeManager.GetAllEmployees();
            return View(employees);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                _employeeManager.AddEmployee(employeeViewModel);
                return RedirectToAction("Index");
            }
            return View(employeeViewModel);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _employeeManager.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                _employeeManager.UpdateEmployee(employeeViewModel);
                return RedirectToAction("Index");
            }
            return View(employeeViewModel);
        }
        [HttpGet]
        public IActionResult Delete1(int id)
        {

            var employee = _employeeManager.DeletedIdDetails(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
           
        }


        [HttpPost, ActionName("Delete")]
        
        public IActionResult Delete(int id)
        {
            _employeeManager.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
