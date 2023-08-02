using MediatR;
using RazorNorthwinds.Data;
using RazorNorthwinds.Mediatr.Queries;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Mediatr.Handlers
{
    public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, IList<Category>>
    {
        private readonly INorthwindsDbRepo _db;

        public GetCategoriesHandler(INorthwindsDbRepo db)
        {
            _db = db;
        }

        public async Task<IList<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _db.GetCategoriesAsync();
        }
    }
}