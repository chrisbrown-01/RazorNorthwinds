using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorNorthwinds.Mediatr.Commands;
using RazorNorthwinds.Mediatr.Notifications;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Pages.CustomerPage
{
    public class CreateMediatrModel : PageModel
    {
        private readonly IMediator _mediator;

        public CreateMediatrModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Customer == null)
            {
                return Page();
            }

            await _mediator.Send(new AddCustomerCommand(Customer));
            await _mediator.Publish(new CustomerRegionUpdatedNotification(Customer));

            return RedirectToPage("./IndexMediatr");
        }
    }
}