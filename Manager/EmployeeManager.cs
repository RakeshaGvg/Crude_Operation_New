using Crude_Operation1.WEB.DataModels;
using Crude_Operation1.WEB.Interface;
using Crude_Operation1.WEB.Models;
using Crude_Operation1.WEB.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Crude_Operation1.WEB.Manager
{
    public class EmployeeManager: IEmployeeManager
    {
        private readonly DataContext _context;

        public EmployeeManager(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<EmployeeViewModel> GetAllEmployees()
        {
            return _context.Employees.Select(e => new EmployeeViewModel
            {
               EmployeeId = e.EmployeeId,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Designation = e.Designation,
                CreatedDate = e.CreatedDate,
            }).ToList();
        }

        public void AddEmployee(EmployeeViewModel employeeViewModel)
        {
            var employee = new DataModels.Employee
            {
               
                FirstName = employeeViewModel.FirstName,
                LastName = employeeViewModel.LastName,
                Designation = employeeViewModel.Designation,
                CreatedDate = employeeViewModel.CreatedDate,    
            };

            _context.Employees.Add(employee);
            _context.SaveChanges();
        }
        public EmployeeViewModel GetEmployeeById(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null) return null;

            EmployeeViewModel model= new EmployeeViewModel
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Designation = employee.Designation,
                CreatedDate = employee.CreatedDate,
            };
            return (model);
        }
        public void UpdateEmployee(EmployeeViewModel employeeViewModel)
        {
            var employee = _context.Employees.Find(employeeViewModel.EmployeeId);
            if (employee != null)
            {
               employee.FirstName = employeeViewModel.FirstName;
               employee.LastName= employeeViewModel.LastName;
                employee.Designation = employeeViewModel.Designation;
                employee.CreatedDate = employeeViewModel.CreatedDate;
                _context.SaveChanges();
            }
        }
        public void DeleteEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }
    }
}

