using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Protocol;
using RazorNorthwinds.Mediatr.Queries;
using RazorNorthwinds.Models;
using System.Text.Json;

namespace RazorNorthwinds.Pages.SalesPage
{
    public class ProductSalesByYearModel : PageModel
    {
        private readonly IMediator _mediator;

        public ProductSalesByYearModel(IMediator mediator)
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

        // ProductSalesByYear?handler=JsonData&year=1997
        public async Task<JsonResult> OnGetJsonData(int year)
        {
            return new JsonResult(await _mediator.Send(new GetProductSalesForYearQuery(year)));
        }
    }
}