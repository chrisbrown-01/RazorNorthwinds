using MediatR;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Mediatr.Queries
{
    public record GetCustomersQuery() : IRequest<IList<Customer>>;
}