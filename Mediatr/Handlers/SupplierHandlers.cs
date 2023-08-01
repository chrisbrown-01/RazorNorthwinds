using MediatR;
using RazorNorthwinds.Data;
using RazorNorthwinds.Mediatr.Queries;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Mediatr.Handlers
{
    public class GetSuppliersHandler : IRequestHandler<GetSuppliersQuery, IList<Supplier>>
    {
        private readonly NorthwindsDbRepo _db;

        public GetSuppliersHandler(NorthwindsDbRepo db)
        {
            _db = db;
        }

        public async Task<IList<Supplier>> Handle(GetSuppliersQuery request, CancellationToken cancellationToken)
        {
            return await _db.GetSuppliersAsync();
        }
    }
}