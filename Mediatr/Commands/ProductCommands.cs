using MediatR;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Mediatr.Commands
{
    public record AddProductCommand(Product Product) : IRequest;
    public record UpdateProductCommand(Product Product) : IRequest;
    public record DeleteProductCommand(int Id) : IRequest;
}