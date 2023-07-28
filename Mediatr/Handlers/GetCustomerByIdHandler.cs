using MediatR;
using RazorNorthwinds.Data;
using RazorNorthwinds.Mediatr.Queries;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Mediatr.Handlers
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, Customer?>
    {
        private readonly NorthwindsDbRepo _db;

        public GetCustomerByIdHandler(NorthwindsDbRepo db)
        {
            _db = db;
        }

        public async Task<Customer?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            return await _db.GetCustomerByIdAsync(request.Id);
        }
    }
}