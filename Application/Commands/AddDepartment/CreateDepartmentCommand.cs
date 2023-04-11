using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.AddDepartmentCommands
{
    public class CreateDepartmentCommand : IRequest
    {
        public string Title { get; set; }
        public string Summary { get; set; }
    }
}
