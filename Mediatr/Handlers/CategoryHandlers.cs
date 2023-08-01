using MediatR;
using RazorNorthwinds.Data;
using RazorNorthwinds.Mediatr.Queries;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Mediatr.Handlers
{
    public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, IList<Category>>
    {
        private readonly NorthwindsDbRepo _db;

        public GetCategoriesHandler(NorthwindsDbRepo db)
        {
            _db = db;
        }

        public async Task<IList<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _db.GetCategoriesAsync();
        }
    }
}