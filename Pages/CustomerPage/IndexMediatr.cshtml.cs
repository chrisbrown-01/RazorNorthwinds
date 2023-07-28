using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorNorthwinds.Models;
using RazorNorthwinds.Queries;

namespace RazorNorthwinds.Pages.CustomerPage
{
    public class IndexMediatrModel : PageModel
    {
        private readonly IMediator _mediator;

        public IndexMediatrModel(IMediator mediator)
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