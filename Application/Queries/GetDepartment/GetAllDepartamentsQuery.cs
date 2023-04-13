using MediatR;
using Thesis.Domain.Entities.Models;

namespace Application.Queries.GetDepartment
{
    public class GetAllDepartamentsQuery : IRequest<IEnumerable<Department>>
    {

    }
}
