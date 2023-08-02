using MediatR;
using RazorNorthwinds.Data;
using RazorNorthwinds.Mediatr.Queries;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Mediatr.Handlers
{
    public class GetProductSalesForYearHandler : IRequestHandler<GetProductSalesForYearQuery, IList<ProductSalesForYear>>
    {
        private readonly INorthwindsDbRepo _db;

        public GetProductSalesForYearHandler(INorthwindsDbRepo db)
        {
            _db = db;
        }

        public async Task<IList<ProductSalesForYear>> Handle(GetProductSalesForYearQuery request, CancellationToken cancellationToken)
        {
            return await _db.GetProductSalesForYearAsync(request.Year);
        }
    }

    public class GetCategorySalesForYearHandler : IRequestHandler<GetCategorySalesForYearQuery, IList<CategorySalesForYear>>
    {
        private readonly INorthwindsDbRepo _db;

        public GetCategorySalesForYearHandler(INorthwindsDbRepo db)
        {
            _db = db;
        }

        public async Task<IList<CategorySalesForYear>> Handle(GetCategorySalesForYearQuery request, CancellationToken cancellationToken)
        {
            return await _db.GetCategorySalesForYearAsync(request.Year);
        }
    }
}