using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorNorthwinds.Mediatr.Queries;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Pages.ProductPage
{
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IList<Product> Product { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Product = await _mediator.Send(new GetProductsQuery());
        }
    }
}