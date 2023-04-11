using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thesis.Domain.Entities.Models;
using Thesis.Persistence.Intrefaces;

namespace Application.Commands.AddDepartmentCommands
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand>
    {
        private readonly IRepository<int, Department> _repository;

        public CreateDepartmentCommandHandler(IRepository<int, Department> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            Department department = new()
            {
                Summary = request.Summary,
                Title = request.Title,
            };

            await _repository.CreateAsync(department);
        }
    }
}
