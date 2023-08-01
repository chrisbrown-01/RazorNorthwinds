using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorNorthwinds.Data;
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

            var orderSubtotal = await _mediator.Send(new GetOrderSubtotalByIdQuery(id));
            OrderSubtotal = orderSubtotal;

            return Page();
        }
    }
}