using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorNorthwinds.Mediatr.Queries;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Pages.ProductPage
{
    public class DetailsModel : PageModel
    {
        private readonly IMediator _mediator;

        public DetailsModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));

            if (product == null)
            {
                return NotFound();
            }

            Product = product;
            return Page();
        }
    }
}