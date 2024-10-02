using Crude_Operation1.WEB.Commands;
using Crude_Operation1.WEB.DataModels;
using Crude_Operation1.WEB.ViewModel;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Crude_Operation1.WEB.CommandHandler
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeViewModel>>
    {
        private readonly DataContext _context;

        public GetAllEmployeesQueryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeViewModel>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Employees
                .ProjectToType<EmployeeViewModel>()
                .ToListAsync(cancellationToken);
        }
    }
}
