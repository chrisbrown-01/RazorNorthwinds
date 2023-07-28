using MediatR;
using RazorNorthwinds.Data;
using RazorNorthwinds.Mediatr.Queries;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Mediatr.Handlers
{
    public class GetCustomersHandler : IRequestHandler<GetCustomersQuery, IList<Customer>>
    {
        private readonly NorthwindsDbRepo _db;

        public GetCustomersHandler(NorthwindsDbRepo db)
        {
            _db = db;
        }

        public async Task<IList<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            return await _db.GetCustomersAsync();
        }
    }
}