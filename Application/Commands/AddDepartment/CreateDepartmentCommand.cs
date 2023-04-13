using MediatR;

namespace Application.Commands.AddDepartmentCommands
{
    public class CreateDepartmentCommand : IRequest
    {
        public string Title { get; set; }
        public string Summary { get; set; }
    }
}
