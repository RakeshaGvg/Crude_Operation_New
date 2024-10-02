using Crude_Operation1.WEB.Commands;
using Crude_Operation1.WEB.DataModels;
using Crude_Operation1.WEB.ViewModel;
using Mapster;
using MediatR;

namespace Crude_Operation1.WEB.CommandHandler
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeViewModel>
    {
        private readonly DataContext _context;

        public GetEmployeeByIdQueryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<EmployeeViewModel> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(request.Id);
            return employee?.Adapt<EmployeeViewModel>();
        }
    }
}
