using MediatR;
using Thesis.Domain.Entities.Models;

namespace Application.Queries.DepartmentPage
{
    public class GetDepartmentPageQuery : IRequest<IEnumerable<Department>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; } = 10;

    }
}
