﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorNorthwinds.Mediatr.Commands;
using RazorNorthwinds.Mediatr.Notifications;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Pages.CustomerPage
{
    public class CreateModel : PageModel
    {
        private readonly IMediator _mediator;

        public CreateModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Customer == null)
            {
                return Page();
            }

            await _mediator.Send(new AddCustomerCommand(Customer));
            await _mediator.Publish(new CustomerRegionUpdatedNotification(Customer));

            return RedirectToPage("./Index");
        }
    }
}