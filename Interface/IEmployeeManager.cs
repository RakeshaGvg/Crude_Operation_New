using Crude_Operation1.WEB.Results;
using Crude_Operation1.WEB.ViewModel;

namespace Crude_Operation1.WEB.Interface
{
    public interface IEmployeeManager
    {
        Task<Result<IEnumerable<EmployeeViewModel>>> GetAllEmployees();
        Task<Result<EmployeeViewModel>> AddEmployee(EmployeeViewModel employeeViewModel);
        Task<Result<EmployeeViewModel>> GetEmployeeById(int id);
        Task<Result> UpdateEmployee(EmployeeViewModel employeeViewModel);
        Task<Result>DeleteEmployee(int id);
        Task<Result<EmployeeViewModel>> DeletedIdDetails(int id);
    }
}
