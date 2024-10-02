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
        //public IActionResult Index()
        //{
        //    var employees = _employeeManager.GetAllEmployees();
        //    return View(employees);
        //}
        public async Task<IActionResult> Index()
        {
            var employees = await _employeeManager.GetAllEmployees(); 
            return View(employees);
        }
        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Create(EmployeeViewModel employeeViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _employeeManager.AddEmployee(employeeViewModel);
        //        return RedirectToAction("Index");
        //    }
        //    return View(employeeViewModel);
        //}
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                await _employeeManager.AddEmployee(employeeViewModel); 
                return RedirectToAction("Index");
            }
            return View(employeeViewModel);
        }
        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    var employee = _employeeManager.GetEmployeeById(id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(employee);
        //}
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _employeeManager.GetEmployeeById(id); 
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        //[HttpPost]
        //public IActionResult Edit(EmployeeViewModel employeeViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _employeeManager.UpdateEmployee(employeeViewModel);
        //        return RedirectToAction("Index");
        //    }
        //    return View(employeeViewModel);
        //}
        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                await _employeeManager.UpdateEmployee(employeeViewModel); 
                return RedirectToAction("Index");
            }
            return View(employeeViewModel);
        }
        //[HttpGet]
        //public IActionResult Delete1(int id)
        //{

        //    var employee = _employeeManager.DeletedIdDetails(id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(employee);

        //}
        [HttpGet]
        public async Task<IActionResult> Delete1(int id)
        {
            var employee = await _employeeManager.DeletedIdDetails(id); 
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        //[HttpPost, ActionName("Delete")]

        //public IActionResult Delete(int id)
        //{
        //    _employeeManager.DeleteEmployee(id);
        //    return RedirectToAction("Index");
        //}
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeManager.DeleteEmployee(id); // Await the async method
            return RedirectToAction("Index");
        }
    }
}
