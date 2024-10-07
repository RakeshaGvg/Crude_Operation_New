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
        
        public async Task<IActionResult> Index()
        {
            var result = await _employeeManager.GetAllEmployees();
            if (result.Success)
            {
                return View(result.Data); 
            }
            return View("Error", result.ErrorMessage); 
        }

        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _employeeManager.AddEmployee(employeeViewModel);
                if (result.Success)
                {
                    return RedirectToAction("Index"); 
                }
                ModelState.AddModelError("", result.ErrorMessage); 
            }
            return View(employeeViewModel); 
        }
        
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _employeeManager.GetEmployeeById(id);
            if (result.Success)
            {
                return View(result.Data); 
            }
            return NotFound(result.ErrorMessage); 
        }

        
        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _employeeManager.UpdateEmployee(employeeViewModel);
                if (result.Success)
                {
                    return RedirectToAction("Index"); 
                }
                ModelState.AddModelError("", result.ErrorMessage); 
            }
            return View(employeeViewModel); 
        }
        
        [HttpGet]
        public async Task<IActionResult> Delete1(int id)
        {
            var result = await _employeeManager.DeletedIdDetails(id);
            if (result.Success)
            {
                return View(result.Data); 
            }
            return NotFound(result.ErrorMessage); 
        }

       
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _employeeManager.DeleteEmployee(id);
            if (result.Success)
            {
                return RedirectToAction("Index"); 
            }
            return NotFound(result.ErrorMessage); 
        }
    }
}
