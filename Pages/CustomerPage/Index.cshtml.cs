using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorNorthwinds.Mediatr.Queries;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Pages.CustomerPage
{
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IList<Customer> Customer { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Customer = await _mediator.Send(new GetCustomersQuery());
        }
    }
}