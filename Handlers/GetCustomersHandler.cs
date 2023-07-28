using MediatR;
using RazorNorthwinds.Data;
using RazorNorthwinds.Models;
using RazorNorthwinds.Queries;

namespace RazorNorthwinds.Handlers
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