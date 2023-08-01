using MediatR;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Mediatr.Queries
{
    public record GetSuppliersQuery() : IRequest<IList<Supplier>>;
}