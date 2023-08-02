using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorNorthwinds.Data;
using RazorNorthwinds.Mediatr.Commands;
using RazorNorthwinds.Mediatr.Handlers;
using RazorNorthwinds.Mediatr.Queries;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Pages.OrderPage
{
    public class CreateModel : PageModel
    {
        private readonly IMediator _mediator;

        public CreateModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["CustomerId"] = new SelectList(await _mediator.Send(new GetCustomersQuery()), "CustomerId", "CompanyName");
            ViewData["EmployeeId"] = new SelectList(await _mediator.Send(new GetEmployeesQuery()), "EmployeeId", "LastName");
            ViewData["ShipVia"] = new SelectList(await _mediator.Send(new GetShippersQuery()), "ShipperId", "CompanyName");
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Order == null)
            {
                return Page();
            }

            await _mediator.Send(new AddOrderCommand(Order));

            return RedirectToPage("./Index");
        }
    }
}