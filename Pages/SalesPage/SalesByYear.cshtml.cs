using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorNorthwinds.Mediatr.Queries;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Pages.SalesPage
{
    public class SalesByYearModel : PageModel
    {
        private readonly IMediator _mediator;

        public SalesByYearModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IList<ProductSalesForYear> ProductSalesForYear { get; set; } = default!;

        [BindProperty]
        internal int Year { get; set; } = 1997;

        public async Task OnGetAsync(int? year)
        {
            if (year.HasValue)
            {
                Year = year.Value;
            }

            ProductSalesForYear = await _mediator.Send(new GetProductSalesForYearQuery(Year));
        }
    }
}