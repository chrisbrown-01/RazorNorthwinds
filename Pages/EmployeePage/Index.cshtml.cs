using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorNorthwinds.Mediatr.Queries;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Pages.EmployeePage
{
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IList<Employee> Employee { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Employee = await _mediator.Send(new GetEmployeesQuery());
        }
    }
}