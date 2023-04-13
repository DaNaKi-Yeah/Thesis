using Application.Commands.AddDepartmentCommands;
using Application.Queries.DepartmentPage;
using Application.Queries.GetDepartment;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;
using Thesis.Domain.Entities.Models;

namespace Thesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task Create(CreateDepartmentCommand command)
        {
            await _mediator.Send(command);
        }

        [HttpGet]
        public async Task<List<Department>> GetAll()
        {
            GetAllDepartamentsQuery query = new GetAllDepartamentsQuery();
           return (await _mediator.Send(query)).ToList();
        }
        [HttpGet ("Page")]
        public async Task<List<Department>> GetPage(int pagenum, int pagesize)
        {
            GetDepartmentPageQuery query = new()
            { 
                PageNumber = pagenum,
                PageSize = pagesize 
            };
            return (await _mediator.Send(query)).ToList() ;

        }

    }
}
