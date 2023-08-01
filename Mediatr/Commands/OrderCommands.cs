using MediatR;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Mediatr.Commands
{
    public record AddOrderCommand(Order Order) : IRequest;
}