﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorNorthwinds.Mediatr.Queries;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Pages.OrderPage
{
    public class DetailsModel : PageModel
    {
        private readonly IMediator _mediator;

        public DetailsModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Order Order { get; set; } = default!;
        public OrderSubtotal? OrderSubtotal { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery(id));

            if (order == null)
            {
                return NotFound();
            }

            Order = order;
            OrderSubtotal = await _mediator.Send(new GetOrderSubtotalByIdQuery(id));  // TODO: note that if sqlite db is being used, these values are randomized

            return Page();
        }
    }
}