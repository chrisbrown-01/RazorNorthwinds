using MediatR;
using RazorNorthwinds.Data;
using RazorNorthwinds.Mediatr.Queries;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Mediatr.Handlers
{
    public class GetShippersHandler : IRequestHandler<GetShippersQuery, IList<Shipper>>
    {
        private readonly INorthwindsDbRepo _db;

        public GetShippersHandler(INorthwindsDbRepo db)
        {
            _db = db;
        }

        public async Task<IList<Shipper>> Handle(GetShippersQuery request, CancellationToken cancellationToken)
        {
            return await _db.GetShippersAsync();
        }
    }
}