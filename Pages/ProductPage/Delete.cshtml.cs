using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorNorthwinds.Mediatr.Commands;
using RazorNorthwinds.Mediatr.Queries;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Pages.ProductPage
{
    public class DeleteModel : PageModel
    {
        private readonly IMediator _mediator;

        public DeleteModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _mediator.Send(new DeleteProductCommand(id));

            return RedirectToPage("./Index");
        }
    }
}