using MediatR;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Mediatr.Queries
{
    public record GetShippersQuery() : IRequest<IList<Shipper>>;
}