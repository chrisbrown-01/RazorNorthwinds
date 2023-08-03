using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorNorthwinds.Mediatr.Queries;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Pages.EmployeePage
{
    public class DetailsModel : PageModel
    {
        private readonly IMediator _mediator;

        public DetailsModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Employee Employee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var employee = await _mediator.Send(new GetEmployeeByIdQuery(id));

            if (employee == null)
            {
                return NotFound();
            }

            Employee = employee;
            return Page();
        }
    }
}