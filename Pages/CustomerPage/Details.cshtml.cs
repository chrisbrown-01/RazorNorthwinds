using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorNorthwinds.Mediatr.Queries;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Pages.CustomerPage
{
    public class DetailsModel : PageModel
    {
        private readonly IMediator _mediator;

        public DetailsModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (String.IsNullOrWhiteSpace(id)) return BadRequest();

            var customer = await _mediator.Send(new GetCustomerByIdQuery(id));

            if (customer == null)
            {
                return NotFound();
            }

            Customer = customer;
            return Page();
        }
    }
}