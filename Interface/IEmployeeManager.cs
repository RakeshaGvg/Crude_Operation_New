using Crude_Operation1.WEB.ViewModel;

namespace Crude_Operation1.WEB.Interface
{
    public interface IEmployeeManager
    {
        Task<IEnumerable<EmployeeViewModel>> GetAllEmployees();
        Task AddEmployee(EmployeeViewModel employeeViewModel);
        Task<EmployeeViewModel> GetEmployeeById(int id);
        Task UpdateEmployee(EmployeeViewModel employeeViewModel);
        Task DeleteEmployee(int id);
        Task<EmployeeViewModel> DeletedIdDetails(int id);
    }
}
