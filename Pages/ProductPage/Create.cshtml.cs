using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorNorthwinds.Mediatr.Commands;
using RazorNorthwinds.Mediatr.Queries;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Pages.ProductPage
{
    public class CreateModel : PageModel
    {
        private readonly IMediator _mediator;

        public CreateModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            //ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            //ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierId");

            ViewData["CategoryId"] = new SelectList(await _mediator.Send(new GetCategoriesQuery()), "CategoryId", "CategoryName");
            ViewData["SupplierId"] = new SelectList(await _mediator.Send(new GetSuppliersQuery()), "SupplierId", "CompanyName");

            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Product == null)
            {
                return Page();
            }

            await _mediator.Send(new AddProductCommand(Product));

            return RedirectToPage("./Index");
        }
    }
}