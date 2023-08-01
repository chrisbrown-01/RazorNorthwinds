using MediatR;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Mediatr.Queries
{
    public record GetOrdersQuery() : IRequest<IList<Order>>;
    public record GetOrderByIdQuery(int Id) : IRequest<Order?>;

    public record GetOrderSubtotalByIdQuery(int Id) : IRequest<OrderSubtotal?>;
}