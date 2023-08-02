using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorNorthwinds.Mediatr.Queries;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Pages.SalesPage
{
    public class CategorySalesByYearModel : PageModel
    {
        private readonly IMediator _mediator;

        public CategorySalesByYearModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IList<CategorySalesForYear> CategorySalesForYear { get; set; } = default!;

        [BindProperty]
        internal int Year { get; set; } = 1997;

        public async Task OnGetAsync(int? year)
        {
            if (year.HasValue)
            {
                Year = year.Value;
            }

            CategorySalesForYear = await _mediator.Send(new GetCategorySalesForYearQuery(Year));
        }

        // CategorySalesByYear?handler=JsonData&year=1997
        public async Task<JsonResult> OnGetJsonData(int year)
        {
            return new JsonResult(await _mediator.Send(new GetCategorySalesForYearQuery(year)));
        }
    }
}