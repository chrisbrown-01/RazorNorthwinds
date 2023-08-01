using MediatR;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Mediatr.Queries
{
    public record GetProductsQuery() : IRequest<IList<Product>>;
    public record GetProductByIdQuery(int Id) : IRequest<Product?>;
}