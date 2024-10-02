using Crude_Operation1.WEB.ViewModel;
using MediatR;

namespace Crude_Operation1.WEB.Commands
{
    public class UpdateEmployeeCommand : IRequest
    {
        public EmployeeViewModel EmployeeViewModel { get; set; }
    }
}
