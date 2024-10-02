using Crude_Operation1.WEB.Commands;
using Crude_Operation1.WEB.DataModels;
using Crude_Operation1.WEB.ViewModel;
using Mapster;
using MediatR;

namespace Crude_Operation1.WEB.CommandHandler
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, EmployeeViewModel>
    {
        private readonly DataContext _context;

        public CreateEmployeeCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<EmployeeViewModel> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = request.EmployeeViewModel.Adapt<DataModels.Employee>();
            await _context.Employees.AddAsync(employee, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return employee.Adapt<EmployeeViewModel>();
        }
    }
}
