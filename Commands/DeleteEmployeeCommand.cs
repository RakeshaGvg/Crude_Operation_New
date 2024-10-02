using MediatR;

namespace Crude_Operation1.WEB.Commands
{
    public class DeleteEmployeeCommand : IRequest
    {
        public int Id { get; set; }
    }
}
