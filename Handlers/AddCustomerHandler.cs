using MediatR;
using RazorNorthwinds.Commands;
using RazorNorthwinds.Data;

namespace RazorNorthwinds.Handlers
{
    public class AddCustomerHandler : IRequestHandler<AddCustomerCommand>
    {
        private readonly NorthwindsDbRepo _db;

        public AddCustomerHandler(NorthwindsDbRepo db)
        {
            _db = db;
        }

        public async Task Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            await _db.AddCustomerAsync(request.Customer);
        }
    }
}