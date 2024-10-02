using Crude_Operation1.WEB.ViewModel;
using MediatR;

namespace Crude_Operation1.WEB.Commands
{
        public class GetEmployeeByIdQuery : IRequest<EmployeeViewModel>
        {
            public int Id { get; set; }
        }
    
}
