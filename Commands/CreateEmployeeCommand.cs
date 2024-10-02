using Crude_Operation1.WEB.ViewModel;
using MediatR;

namespace Crude_Operation1.WEB.Commands
{
   
    public class CreateEmployeeCommand : IRequest<EmployeeViewModel>
    {
        public EmployeeViewModel EmployeeViewModel { get; set; }
    }
}
