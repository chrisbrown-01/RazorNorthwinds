using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorNorthwinds.Mediatr.Queries;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Pages.OrderPage
{
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IList<Order> Order { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Order = await _mediator.Send(new GetOrdersQuery());
        }
    }
}