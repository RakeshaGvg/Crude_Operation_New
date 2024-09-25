using Crude_Operation1.WEB.ViewModel;

namespace Crude_Operation1.WEB.Interface
{
    public interface IEmployeeManager
    {
        IEnumerable<EmployeeViewModel> GetAllEmployees();
        void AddEmployee(EmployeeViewModel employeeViewModel);
        EmployeeViewModel GetEmployeeById(int id);
        void UpdateEmployee(EmployeeViewModel employeeViewModel);
        void DeleteEmployee(int id);
    }
}
