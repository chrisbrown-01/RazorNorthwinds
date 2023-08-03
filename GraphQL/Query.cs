using MediatR;
using RazorNorthwinds.Data;
using RazorNorthwinds.Mediatr.Queries;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.GraphQL
{
    public class Query
    {
        private readonly IMediator _mediator;

        public Query(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IList<Customer>> GetCustomersAsync()
        {
            return await _mediator.Send(new GetCustomersQuery());
        }

        public async Task<Customer?> GetCustomerByIdAsync(string Id)
        {
            return await _mediator.Send(new GetCustomerByIdQuery(Id));
        }
    }
}