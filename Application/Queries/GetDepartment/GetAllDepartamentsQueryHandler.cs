using MediatR;
using Thesis.Domain.Entities.Models;
using Thesis.Persistence.Intrefaces;

namespace Application.Queries.GetDepartment
{
    internal class GetAllDepartamentsQueryHandler : IRequestHandler<GetAllDepartamentsQuery, IEnumerable<Department>>
    {
        private readonly IRepository<int, Department> _repository;

        public GetAllDepartamentsQueryHandler(IRepository<int, Department> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Department>> Handle(GetAllDepartamentsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
