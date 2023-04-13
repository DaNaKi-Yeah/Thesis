using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Thesis.Domain.Entities.Models;
using Thesis.Persistence.Intrefaces;

namespace Application.Queries.DepartmentPage
{
    public class GetDepartmentPageQueryHandler : IRequestHandler<GetDepartmentPageQuery, IEnumerable<Department>>
    {
        private readonly IRepository<int, Department> _repository;

        public GetDepartmentPageQueryHandler(IRepository<int, Department> repository)
        {
            _repository = repository;
        }

        public  async Task<IEnumerable<Department>> Handle(GetDepartmentPageQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetQuery()
                .Skip(request.PageNumber * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();
        }
    }
}
