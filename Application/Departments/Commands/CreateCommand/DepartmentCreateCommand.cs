using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Departments.Commands.CreateCommand
{
    public class DepartmentCreateCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Summary { get; set; }
    }
}
