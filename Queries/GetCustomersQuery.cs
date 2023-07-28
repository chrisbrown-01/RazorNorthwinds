using MediatR;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Queries
{
    public record GetCustomersQuery() : IRequest<IList<Customer>>;
}