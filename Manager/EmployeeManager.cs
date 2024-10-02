using Crude_Operation1.WEB.Commands;
using Crude_Operation1.WEB.DataModels;
using Crude_Operation1.WEB.Interface;
using Crude_Operation1.WEB.Models;
using Crude_Operation1.WEB.ViewModel;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Crude_Operation1.WEB.Manager
{
    public class EmployeeManager: IEmployeeManager
    {
       // private readonly DataContext _context;
        private readonly IMediator _mediator;
        //public EmployeeManager(DataContext context)
        //{
        //    _context = context;
        //}
        public EmployeeManager(IMediator mediator)
        {
            _mediator = mediator;
        }
        //public IEnumerable<EmployeeViewModel> GetAllEmployees()
        //{
        //    //return _context.Employees.Select(e => new EmployeeViewModel
        //    //{
        //    //    EmployeeId = e.EmployeeId,
        //    //    FirstName = e.FirstName,
        //    //    LastName = e.LastName,
        //    //    Designation = e.Designation,
        //    //    CreatedDate = e.CreatedDate,
        //    //}).ToList();
        //    return _context.Employees
        //        .ProjectToType<EmployeeViewModel>() 
        //        .ToList();
        //}
        public async Task<IEnumerable<EmployeeViewModel>> GetAllEmployees()
        {
            var query = new GetAllEmployeesQuery();
            return await _mediator.Send(query);
        }

        //public void AddEmployee(EmployeeViewModel employeeViewModel)
        //{
        //    //var employee = new DataModels.Employee
        //    //{

        //    //    FirstName = employeeViewModel.FirstName,
        //    //    LastName = employeeViewModel.LastName,
        //    //    Designation = employeeViewModel.Designation,
        //    //    CreatedDate = employeeViewModel.CreatedDate,    
        //    //};

        //    //_context.Employees.Add(employee);
        //    //_context.SaveChanges();
        //    var employee = employeeViewModel.Adapt<DataModels.Employee>(); 
        //    _context.Employees.Add(employee);
        //    _context.SaveChanges();
        //}
        public async Task AddEmployee(EmployeeViewModel employeeViewModel)
        {
            var command = new CreateEmployeeCommand { EmployeeViewModel = employeeViewModel };
            await _mediator.Send(command);
        }
        //public EmployeeViewModel GetEmployeeById(int id)
        //{
        //    //var employee = _context.Employees.Find(id);
        //    //if (employee == null) return null;

        //    //EmployeeViewModel model= new EmployeeViewModel
        //    //{
        //    //    EmployeeId = employee.EmployeeId,
        //    //    FirstName = employee.FirstName,
        //    //    LastName = employee.LastName,
        //    //    Designation = employee.Designation,
        //    //    CreatedDate = employee.CreatedDate,
        //    //};
        //    //return (model);
        //    var employee = _context.Employees.Find(id);
        //    return employee?.Adapt<EmployeeViewModel>();
        //}
        public async Task<EmployeeViewModel> GetEmployeeById(int id)
        {
            var query = new GetEmployeeByIdQuery { Id = id };
            return await _mediator.Send(query);
        }
        //public void UpdateEmployee(EmployeeViewModel employeeViewModel)
        //{
        //    //var employee = _context.Employees.Find(employeeViewModel.EmployeeId);
        //    //if (employee != null)
        //    //{
        //    //   employee.FirstName = employeeViewModel.FirstName;
        //    //   employee.LastName= employeeViewModel.LastName;
        //    //    employee.Designation = employeeViewModel.Designation;
        //    //    employee.CreatedDate = employeeViewModel.CreatedDate;
        //    //    _context.SaveChanges();
        //    //}
        //    var employee = _context.Employees.Find(employeeViewModel.EmployeeId);
        //    if (employee != null)
        //    {
        //        employeeViewModel.Adapt(employee); 
        //        _context.SaveChanges();
        //    }
        //}
        public async Task UpdateEmployee(EmployeeViewModel employeeViewModel)
        {
            var command = new UpdateEmployeeCommand { EmployeeViewModel = employeeViewModel };
            await _mediator.Send(command);
        }

        //public EmployeeViewModel DeletedIdDetails(int id)
        //{
        //    //var employee = _context.Employees.Find(id);
        //    //if (employee == null) return null;

        //    //EmployeeViewModel model = new EmployeeViewModel
        //    //{
        //    //    EmployeeId = employee.EmployeeId,
        //    //    FirstName = employee.FirstName,
        //    //    LastName = employee.LastName,
        //    //    Designation = employee.Designation,
        //    //    CreatedDate = employee.CreatedDate,
        //    //};
        //    //return (model);
        //    var employee = _context.Employees.Find(id);
        //    return employee?.Adapt<EmployeeViewModel>(); 
        //}
        public async Task<EmployeeViewModel> DeletedIdDetails(int id)
        {
            var query = new GetEmployeeByIdQuery { Id = id };
            return await _mediator.Send(query);
        }
        //public void DeleteEmployee(int id)
        //{
        //    var employee = _context.Employees.Find(id);
        //    if (employee != null)
        //    {
        //        _context.Employees.Remove(employee);
        //        _context.SaveChanges();
        //    }

        //}
        public async Task DeleteEmployee(int id)
        {
            var command = new DeleteEmployeeCommand { Id = id };
            await _mediator.Send(command);
        }
    }
}

