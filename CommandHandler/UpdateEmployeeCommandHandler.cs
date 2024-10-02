using Crude_Operation1.WEB.Commands;
using Crude_Operation1.WEB.DataModels;
using Mapster;
using MediatR;

namespace Crude_Operation1.WEB.CommandHandler
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly DataContext _context;

        public UpdateEmployeeCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(request.EmployeeViewModel.EmployeeId);
            if (employee != null)
            {
                request.EmployeeViewModel.Adapt(employee);
                await _context.SaveChangesAsync(cancellationToken);
            }
            return Unit.Value;
        }
    }
}
