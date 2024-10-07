using Crude_Operation1.WEB.Commands;
using Crude_Operation1.WEB.DataModels;
using Crude_Operation1.WEB.Interface;
using Crude_Operation1.WEB.Models;
using Crude_Operation1.WEB.Results;
using Crude_Operation1.WEB.ViewModel;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Crude_Operation1.WEB.Manager
{
    public class EmployeeManager: IEmployeeManager
    {
      
        private readonly IMediator _mediator;
        
        public EmployeeManager(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public async Task<Result<IEnumerable<EmployeeViewModel>>> GetAllEmployees()
        {
            var query = new GetAllEmployeesQuery();
            var employees = await _mediator.Send(query);
            return Result<IEnumerable<EmployeeViewModel>>.Ok(employees);
        }

        
        public async Task<Result<EmployeeViewModel>> AddEmployee(EmployeeViewModel employeeViewModel)
        {
            try
            {
                var command = new CreateEmployeeCommand { EmployeeViewModel = employeeViewModel };
                await _mediator.Send(command);
                return Result<EmployeeViewModel>.Ok(employeeViewModel); 
            }
            catch (Exception ex)
            {
                return Result<EmployeeViewModel>.Fail(ex.Message);
            }
        }

        
        public async Task<Result<EmployeeViewModel>> GetEmployeeById(int id)
        {
            try
            {
                var query = new GetEmployeeByIdQuery { Id = id };
                var employee = await _mediator.Send(query);

                if (employee == null)
                {
                    return Result<EmployeeViewModel>.Fail("Employee not found.");
                }

                return Result<EmployeeViewModel>.Ok(employee);
            }
            catch (Exception ex)
            {
                return Result<EmployeeViewModel>.Fail(ex.Message);
            }
        }
       
        public async Task<Result> UpdateEmployee(EmployeeViewModel employeeViewModel)
        {
            try
            {
                var command = new UpdateEmployeeCommand { EmployeeViewModel = employeeViewModel };
                await _mediator.Send(command);
                return Result.Ok(); 
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

       
        public async Task<Result<EmployeeViewModel>> DeletedIdDetails(int id)
        {
            return await GetEmployeeById(id);
        }
       
        public async Task<Result> DeleteEmployee(int id)
        {
            try
            {
                var command = new DeleteEmployeeCommand { Id = id };
                await _mediator.Send(command);
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }
    }
}

